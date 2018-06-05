using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Manager
{
    public class BuffTool : AbstractTool
    {
        public static ToolEnum toolEnum;

        public override void Awake()
        {
            base.Awake();
            toolEnum = ToolEnum;
        }

        public override ToolEnum GetToolEnum()
        {
            return toolEnum;
        }
    }
}
