using EnumsNew;
using System.Collections.Generic;
using UnityEngine;

namespace Delivery
{
    public abstract class Result
    {
        public abstract void Apply(GameObject owner, GameObject target, DeliveryPack pack, DeliveryPack newPack, List<Result> results, Dictionary<Delivery_Pack_Shifts, AttributeShift> shifts);
    }
}