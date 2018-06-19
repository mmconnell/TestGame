using Manager;
using UnityEngine;

namespace Utility
{
    public class RangeNumber : DynamicNumber
    {
        private DynamicNumber low;
        private DynamicNumber high;

        public RangeNumber(DynamicNumber low, DynamicNumber high)
        {
            this.low = low;
            this.high = high;
        }

        public override float GetAmount(ToolManager owner, ToolManager target)
        {
            float lowVal = low.GetIntAmount(owner, target);
            float highVal = high.GetIntAmount(owner, target);
            return (InformationManager.RandomFloat(highVal - lowVal) + lowVal);
        }

        public override float GetAmount(ToolManager source)
        {
            float lowVal = low.GetIntAmount(source);
            float highVal = high.GetIntAmount(source);
            return (InformationManager.RandomFloat(highVal - lowVal) + lowVal);
        }
    }
}
