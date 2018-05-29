using EnumsNew;
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

        public override float GetAmount(GameObject owner, GameObject target)
        {
            return Amount;
        }

        public override float GetAmount(GameObject source)
        {
            return Amount;
        }
    }
}