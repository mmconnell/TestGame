using EnumsNew;
using Manager;
using UnityEngine;

namespace Utility
{
    public class FlatNumber : DynamicNumber
    {
        private float Amount { get; set; }

        public FlatNumber(float amount)
        {
            Amount = amount;
        }

        public override float GetAmount(ToolManager owner, ToolManager target)
        {
            return Amount;
        }

        public override float GetAmount(ToolManager source)
        {
            return Amount;
        }
    }
}