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

        public override void Apply(GameObject owner, GameObject target, I_DeliveryPack pack, I_DeliveryPack newPack, List<Result> results, Dictionary<Delivery_Pack_Shifts, NumberShift> shifts) {
            //newPack.AddDamage(DamagePack);
        }
    }
}