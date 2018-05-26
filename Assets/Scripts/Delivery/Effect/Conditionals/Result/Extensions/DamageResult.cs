using System.Collections.Generic;
using EnumsNew;
using UnityEngine;

namespace Delivery
{
    public class DamageResult : Result
    {
        public DamagePack DamagePack {get; set;}

        public DamageResult(DamagePack damagePack) {
            DamagePack = damagePack;
        }

        public override void Apply(GameObject owner, GameObject target, DeliveryPack pack, DeliveryPack newPack, List<Result> results, Dictionary<Delivery_Pack_Shifts, AttributeShift> shifts) {
            //newPack.AddDamage(DamagePack);
        }
    }
}