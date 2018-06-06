using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class GenerateEnum : EditorWindow, IPointerEnterHandler
 {
    public static Regex nameSpace = new Regex(@"\A\s*namespace ([^\s]*)\s*\{\s*(.*)\}\s*\Z", RegexOptions.Singleline);
    public static Regex enumRegex = new Regex(@"public enum\s*([^\s]*)\s*\{([^\}]*)\}\s*", RegexOptions.Singleline);
    public static Regex enumValues = new Regex(@"\s*([^,\s]+)\s*,?", RegexOptions.Singleline);
    
    public static string standardPathName = "Assets/Scripts/Enum/Enum.cs";

    public static int enumsPerLine = 5;

    [MenuItem("Tools/ManageEnums")]
    public static void ShowWindow()
    {
        GetWindow(typeof(GenerateEnum));
    }

    private List<string> enum_names;
    private List<List<string>> enum_values;
    private string nameSpaceName;

    private string nameToAdd;
    private string enumToAdd;
    private StreamWriter sw;
    private Vector2 scrollPos;

    private bool enumJustAdded;

    public int index = 0;
    public int last = 0;

    void OnGUI()
    {
        EditorGUIUtility.labelWidth = 80;
        if(last != index)
        {
            enumToAdd = "";
            nameToAdd = "";
        }
        if(enum_names == null || enum_values == null)
        {
            BuildLists();
        }
        GUILayout.Label("Enum Editor", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        {
            nameSpaceName = EditorGUILayout.TextField("Name Space Name: ", nameSpaceName);
        }
        EditorGUILayout.EndHorizontal();
        index = EditorGUILayout.Popup(index, enum_names.ToArray());
        last = index;
        if(index == enum_names.Count - 1)
        {
            EditorGUILayout.BeginHorizontal("box");
            {
                nameToAdd = FormatString(EditorGUILayout.TextField("Add New Enum Type: ", nameToAdd), false);

                if (GUILayout.Button("Add"))
                {
                    if (nameToAdd != null && !nameToAdd.Equals("") && !enum_names.Contains(nameToAdd))
                    {
                        nameToAdd = FormatString(nameToAdd, false);
                        enum_names.Insert(enum_names.Count - 1, nameToAdd);
                        enum_values.Insert(enum_values.Count - 1, new List<string>());
                        index++;
                        last++;
                        nameToAdd = "";
                    }
                }
            }
            EditorGUILayout.EndHorizontal();
        }
        else
        {
            EditorGUILayout.BeginHorizontal("box");
            {
                enum_names[index] = FormatString(EditorGUILayout.TextField("Enum Type: ", enum_names[index]), false);
                if(GUILayout.Button("Delete"))
                {
                    enum_names.RemoveAt(index);
                }
            }
            EditorGUILayout.EndHorizontal();
        }
        List<string> enumVals = enum_values[index];
        if (index != enum_names.Count - 1)
        {
            EditorGUILayout.BeginVertical("box");
            {
                scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
                {
                    for (int x = 0; x < enumVals.Count; x++)
                    {
                        EditorGUILayout.BeginHorizontal("box");
                        {
                            enumVals[x] = FormatString(EditorGUILayout.TextField("Enum " + (x + 1) + ":", enumVals[x]), true);
                            if (GUILayout.Button("Delete"))
                            {
                                enumVals.RemoveAt(x);
                                x--;
                            }
                        }
                        EditorGUILayout.EndHorizontal();
                    }
                }
                EditorGUILayout.EndScrollView();
                
                EditorGUILayout.BeginHorizontal("box");
                {
                    GUI.SetNextControlName("AddNewEnum");
                    enumToAdd = FormatString(EditorGUILayout.TextField("Add Enum:", enumToAdd), true);
                    GUI.GetNameOfFocusedControl().Equals("AddNewEnum");
                   
                    if(GUI.GetNameOfFocusedControl().Equals("AddNewEnum"))
                    {
                        GUI.FocusControl("AddNewEnum");
                    }
                    if (enumJustAdded)
                    {
                        GUI.FocusControl("AddNewEnum");
                        
                        enumJustAdded = false;
                    }
                    if (GUILayout.Button("Add"))
                    {
                        if (enumToAdd != null && !enumToAdd.Equals("") && !enumVals.Contains(enumToAdd))
                        {
                            enumVals.Add(enumToAdd);
                            enumToAdd = "";
                            enumJustAdded = true;
                        }
                    }
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.BeginHorizontal();
        {
            if (GUILayout.Button("Save Changes", GUILayout.MinHeight(30)))
            {
                UpdateFile();
            }
        }
        EditorGUILayout.EndHorizontal();
    }

    private string FormatString(string toFormat, bool upper)
    {
        if (toFormat != null && !toFormat.Equals(""))
        {
            toFormat = toFormat.ToLower();
            bool space = true;
            for (int x = 0; x < toFormat.Length; x++)
            {
                bool first = x == 0;
                bool last = x == (toFormat.Length - 1);
                string current = toFormat[x] + "";
                if (space && (toFormat[x] == ' ' || toFormat[x] == '_'))
                {
                    if (first)
                    {
                        if (!last)
                        {
                            toFormat = toFormat.Substring(1);
                            x--;
                        }
                        else
                        {
                            return "";
                        }
                    }
                    else
                    {
                        toFormat = toFormat.Substring(0, x) + (last ? "" : toFormat.Substring(x + 1));
                        x--;
                    }
                }
                else if (space)
                {
                    toFormat = (first ? "" : toFormat.Substring(0, x)) + current.ToUpper() + (last ? "" : toFormat.Substring(x + 1));
                }
                else
                {
                    if (toFormat[x] == ' ')
                    {
                        toFormat = (first ? "" : toFormat.Substring(0, x) + (last ? "" : "_")) + (last ? "" : toFormat.Substring(x + 1));
                        if (first)
                        {
                            x--;
                        }
                    }
                }
                if (x != -1)
                {
                    space = false;
                    if (!last && x < toFormat.Length && x >= 0 && (toFormat[x] == ' ' || toFormat[x] == '_'))
                    {
                        space = true;
                    }
                }
            }
            if(toFormat.Length != 0 && toFormat[toFormat.Length - 1] == '_')
            {
                toFormat = toFormat.Substring(0, toFormat.Length - 1);
            }
            if(upper)
            {
                toFormat = toFormat.ToUpper();
            }
            return toFormat;
        }
        return "";
    }

    private void UpdateFile()
    {
        string toWrite = "";
        toWrite += ("namespace " + nameSpaceName + "\r\n{");
        for (int x = 0; x < enum_names.Count - 1; x++) 
        {
            toWrite += "\r\n";
            string enumName = enum_names[x];
            List<string> enumEntries = enum_values[x];
            toWrite += WriteTabs(1);
            toWrite += ("public enum " + enumName) + "\r\n";
            toWrite += WriteTabs(1);
            toWrite += ("{");
            for (int i = 0; i < enumEntries.Count; i++)
            {
                if (i % enumsPerLine == 0)
                {
                    toWrite += "\r\n";
                    toWrite += WriteTabs(2);
                }
                if (i != enumEntries.Count - 1)
                {
                    toWrite += (enumEntries[i] + ", ");
                }
                else
                {
                    toWrite += (enumEntries[i]);
                }
            }
            toWrite += "\r\n";
            toWrite += WriteTabs(1);
            toWrite += ("}") + "\r\n";
        }
        toWrite += ("}") + "\r\n";
        sw = new StreamWriter(standardPathName);
        sw.WriteLine(toWrite);
        sw.Close();
        AssetDatabase.Refresh();
    }

    private string WriteTabs(int tabs)
    {
        string toReturn = "";
        for(int x = 0; x < tabs; x++)
        {
            toReturn += ("\t");
        }
        return toReturn;
    }

    private void BuildLists()
    {
        List<string> enumNames = new List<string>();
        List<List<string>> enumValuesLists = new List<List<string>>();
        if (File.Exists(standardPathName))
        {
            string fileContents = "";
            using (StreamReader streamReader = new StreamReader(standardPathName))
            {
                fileContents = streamReader.ReadToEnd();
            }

            MatchCollection enumSpaceMatchCollection = nameSpace.Matches(fileContents);
            Match enumSpaceMatch = enumSpaceMatchCollection[0];
            GroupCollection enumSpaceGroups = enumSpaceMatch.Groups;
            nameSpaceName = enumSpaceGroups[1].ToString();
            string enumSpaceString = enumSpaceGroups[2].ToString();

            MatchCollection enumRegexMatchCollection = enumRegex.Matches(enumSpaceString);
            foreach (Match enumRegexMatch in enumRegexMatchCollection)
            {
                GroupCollection enumRegexGroups = enumRegexMatch.Groups;
                enumNames.Add(FormatString(enumRegexGroups[1].ToString(), false));
                List<string> enumNamesList = new List<string>();
                enumValuesLists.Add(enumNamesList);
                string enumRegexString = enumRegexGroups[2].ToString();
                MatchCollection enumValuesMatchCollection = enumValues.Matches(enumRegexString);
                foreach (Match enumValuesMatch in enumValuesMatchCollection)
                {
                    GroupCollection enumValuesGroups = enumValuesMatch.Groups;
                    enumNamesList.Add(FormatString(enumValuesGroups[1].ToString(), true));
                }
            }
        }
        enum_names = enumNames;
        enum_names.Add("Add New");
        enum_values = enumValuesLists;
        enum_values.Add(new List<string>());
    }

    void OnDisable()
    {
        UpdateFile();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(eventData);    
    }
}