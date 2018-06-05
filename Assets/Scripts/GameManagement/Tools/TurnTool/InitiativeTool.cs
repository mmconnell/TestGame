using UnityEngine;
using System.Collections;

namespace Manager
{
    public class InitiativeTool : AbstractTool
    {
        public static ToolEnum toolEnum;

        public int initiativeValue;

        public override void Awake()
        {
            base.Awake();
            toolEnum = ToolEnum;
        }

        // Use this for initialization
        void Start()
        {

        }

        public void CalculateInitiative()
        {
            initiativeValue = 1;
        }

        public override ToolEnum GetToolEnum()
        {
            return toolEnum;
        }
    }
}