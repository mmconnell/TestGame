using EnumsNew;
using System.Collections.Generic;
using UnityEngine;

namespace Delivery
{
    public abstract class Result
    {
        public abstract void Apply(GameObject owner, GameObject target, I_DeliveryPack pack, I_DeliveryPack newPack, List<Result> results, Dictionary<Delivery_Pack_Shifts, NumberShift> shifts);
    }
}