using EnumsNew;
using System.Collections.Generic;
using UnityEngine;

namespace Delivery
{
    public abstract class Condition
    {
        public Conditional Conditional {get; set;}
        
        public Condition(Conditional conditional) {
            Conditional = conditional;
        }

        public abstract bool Apply(GameObject owner, GameObject target, DeliveryPack pack, DeliveryPack newPack, List<Result> results, Dictionary<Delivery_Pack_Shifts, AttributeShift> shifts);
    }
}
