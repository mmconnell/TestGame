using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Manager
{
    public abstract class AbstractTool : MonoBehaviour
    {
        public ToolEnum ToolEnum { get; private set; }
        public ToolManager toolManager;
        public bool invalid;

        public virtual void Awake()
        {
            ToolEnum = GetToolEnum();
            if (ToolEnum == null)
            {
                ToolEnum = new ToolEnum(GetType());
            }
            toolManager = gameObject.GetComponent<ToolManager>();
            if (toolManager == null)
            {
                toolManager = gameObject.AddComponent<ToolManager>();
                toolManager.Init();
            }
            AbstractTool abstractTool = toolManager.Get(ToolEnum);
            if (abstractTool)
            {
                invalid = true;
                Destroy(this);
            }
            else
            {
                toolManager.Add(ToolEnum, this);
            }
        }

        public virtual void OnDestroy()
        {
            if (!invalid)
            {
                toolManager.Remove(ToolEnum);
            }
        }

        public abstract ToolEnum GetToolEnum();
    }
}
