using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Utility
{
    public abstract class DynamicNumber
    {
        public abstract float GetAmount(ToolManager owner, ToolManager target);
        public abstract float GetAmount(ToolManager source);

        public int GetIntAmount(ToolManager owner, ToolManager target)
        {
            return (int)GetAmount(owner, target);
        }

        public int GetIntAmount(ToolManager source)
        {
            return (int)GetAmount(source);
        }
    }
}
