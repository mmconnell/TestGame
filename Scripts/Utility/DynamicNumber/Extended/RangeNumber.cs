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
            int lowVal = low.GetIntAmount(owner, target);
            int highVal = high.GetIntAmount(owner, target);
            return (InformationManager.RandomNumber(highVal - lowVal) + lowVal);
        }

        public override float GetAmount(ToolManager source)
        {
            int lowVal = low.GetIntAmount(source);
            int highVal = high.GetIntAmount(source);
            return (InformationManager.RandomNumber(highVal - lowVal) + lowVal);
        }
    }
}
