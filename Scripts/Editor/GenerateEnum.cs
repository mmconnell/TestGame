using UnityEditor;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
 
 public class GenerateEnum : EditorWindow
 {
    public static Regex nameSpace = new Regex(@"\A\s*namespace Enums\s*\{\s*(.*)\}\s*\Z", RegexOptions.Singleline);
    public static Regex enumRegex = new Regex(@"public enum\s*([^\s]*)\s*\{([^\}]*)\}\s*", RegexOptions.Singleline);
    public static Regex enumValues = new Regex(@"\s*([^,\s]+)\s*,?", RegexOptions.Singleline);
    public static string standardPathName = "Assets/Scripts/Enum/Enum.cs";
    public static string namespaceName = "Enums";
    public static int enumsPerLine = 5;

    [MenuItem("Tools/GenerateEnum")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(GenerateEnum));
    }

    private List<string> enum_names;
    private List<List<string>> enum_values;
    private string nameToAdd;
    private string enumToAdd;
    private StreamWriter sw;
    private Vector2 scrollPos;

    public int index = 0;
    public int last = 0;

    void OnGUI()
    {
        if(last != index)
        {
            enumToAdd = "";
            nameToAdd = "";
        }
        if(enum_names == null || enum_values == null)
        {
            buildLists();
        }
        GUILayout.Label("Enum Editor", EditorStyles.boldLabel);
        index = EditorGUILayout.Popup(index, enum_names.ToArray());
        if(index == enum_names.Count - 1)
        {
            EditorGUILayout.BeginHorizontal("box");
            nameToAdd = formatString(EditorGUILayout.TextField("Add New Enum Type: ", nameToAdd), false);
            
            if(GUILayout.Button("Add"))
            {
                if(nameToAdd != null && !nameToAdd.Equals("") && !enum_names.Contains(nameToAdd))
                {
                    nameToAdd = formatString(nameToAdd, false);
                    enum_names.Insert(enum_names.Count-1, nameToAdd);
                    enum_values.Insert(enum_values.Count-1, new List<string>());
                    index++;
                    last++;
                    UpdateFile();
                    nameToAdd = "";
                }
            }
            EditorGUILayout.EndHorizontal();
        }
        else
        {
            EditorGUILayout.BeginHorizontal("box");
            enum_names[index] = formatString(EditorGUILayout.TextField("Enum Type: ", enum_names[index]), false);
            EditorGUILayout.EndHorizontal();
        }
        List<string> enumVals = enum_values[index];
        if (index != enum_names.Count - 1)
        {
            EditorGUILayout.BeginVertical("box");
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
            for (int x = 0; x < enumVals.Count; x++)
            {
                EditorGUILayout.BeginHorizontal("box");
                enumVals[x] = formatString(EditorGUILayout.TextField("Enum " + (x + 1) + ":", enumVals[x]), true);
                if(GUILayout.Button("Delete"))
                {
                    enumVals.RemoveAt(x);
                    x--;
                    UpdateFile();
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.BeginHorizontal("box");
            enumToAdd = formatString(EditorGUILayout.TextField("Add:", enumToAdd), true);
            if (GUILayout.Button("Add"))
            {
                if (enumToAdd != null && !enumToAdd.Equals("") && !enumVals.Contains(enumToAdd))
                {
                    enumVals.Add(enumToAdd);
                    UpdateFile();
                    enumToAdd = "";
                }
            }
            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
        }
    }

    private string formatString(string toFormat, bool upper)
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
        toWrite += ("namespace " + namespaceName + "\n{");
        for (int x = 0; x < enum_names.Count - 1; x++) 
        {
            toWrite += "\n";
            string enumName = enum_names[x];
            List<string> enumEntries = enum_values[x];
            toWrite += writeTabs(1);
            toWrite += ("public enum " + enumName) + "\n";
            toWrite += writeTabs(1);
            toWrite += ("{") + "\n";
            for (int i = 0; i < enumEntries.Count; i++)
            {
                if (i % enumsPerLine == 0)
                {
                    toWrite += "\n";
                    toWrite += writeTabs(2);
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
            toWrite += "\n";
            toWrite += writeTabs(1);
            toWrite += ("}") + "\n";
        }
        toWrite += ("}") + "\n";
        sw = new StreamWriter(standardPathName);
        sw.WriteLine(toWrite);
        sw.Close();
        AssetDatabase.Refresh();
    }

    private string writeTabs(int tabs)
    {
        string toReturn = "";
        for(int x = 0; x < tabs; x++)
        {
            toReturn += ("\t");
        }
        return toReturn;
    }

    void buildLists()
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
            string enumSpaceString = enumSpaceGroups[1].ToString();

            MatchCollection enumRegexMatchCollection = enumRegex.Matches(enumSpaceString);
            foreach (Match enumRegexMatch in enumRegexMatchCollection)
            {
                GroupCollection enumRegexGroups = enumRegexMatch.Groups;
                enumNames.Add(formatString(enumRegexGroups[1].ToString(), false));
                List<string> enumNamesList = new List<string>();
                enumValuesLists.Add(enumNamesList);
                string enumRegexString = enumRegexGroups[2].ToString();
                MatchCollection enumValuesMatchCollection = enumValues.Matches(enumRegexString);
                foreach (Match enumValuesMatch in enumValuesMatchCollection)
                {
                    GroupCollection enumValuesGroups = enumValuesMatch.Groups;
                    enumNamesList.Add(formatString(enumValuesGroups[1].ToString(), true));
                }
            }
        }
        enum_names = enumNames;
        enum_names.Add("Add New");
        enum_values = enumValuesLists;
        enum_values.Add(new List<string>());
    }

    void OnEnable()
    {
        buildLists();
    }
 }
