using EnumsNew;
using Manager;
using UnityEngine;

namespace Utility
{
    public class LevelBasedNumber : DynamicNumber
    {
        private DynamicNumber DynamicNumber { get; set; }
        private bool SourceIsOwner { get; set; }

        public LevelBasedNumber(DynamicNumber dynamicNumber, bool sourceIsOwner)
        {
            DynamicNumber = dynamicNumber;
            SourceIsOwner = sourceIsOwner;
        }

        public override float GetAmount(ToolManager owner, ToolManager target)
        {
            ToolManager source = SourceIsOwner ? owner : target;
            if (source == null)
            {
                return 0;
            }
            //Logic
            return DynamicNumber.GetAmount(owner, target);
        }

        public override float GetAmount(ToolManager source)
        {
            if (source == null)
            {
                return 0;
            }
            //Logic
            return DynamicNumber.GetAmount(source);
        }
    }
}