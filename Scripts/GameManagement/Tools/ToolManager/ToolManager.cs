using DeliverySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Manager
{
    public class ToolManager : MonoBehaviour
    {
        private static ToolEnum[] tools = new ToolEnum[InformationManager.GetMaxTools()];
        private static int count = 0;

        public I_Position position;
        public Rigidbody2D rigidBody;

        public static void AddTool(ToolEnum toolEnum)
        {
            tools[count] = toolEnum;
            count++;
        }

        public static int Count()
        {
            return count;
        }

        private ToolEnumList innerTools;
        private bool invalid = false;

        public void Init()
        {
            innerTools = new ToolEnumList();
        }

        private void Awake()
        {
            if (InformationManager.GetRegisteredToolManager(gameObject))
            {
                invalid = true;
                Destroy(this);
            }
            else
            {
                InformationManager.RegisterToolManager(gameObject, this);
                position = new ObjectPosition(this);
                rigidBody = GetComponent<Rigidbody2D>();
            }
        }

        private void OnDestroy()
        {
            if (!invalid)
            {
                InformationManager.UnRegisterToolManager(gameObject);
            }
        }

        public AbstractTool Get(ToolEnum toolEnum)
        {
            return innerTools.Get(toolEnum);
        }

        public void Add(ToolEnum toolEnum, AbstractTool tool)
        {
            innerTools.Add(toolEnum, tool);
        }

        public void Remove(ToolEnum toolEnum)
        {
            if (innerTools != null)
            {
                innerTools.Remove(toolEnum);
            }
        }
    }
}
