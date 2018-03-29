using System;
using System.Collections.Generic;
using EnumsNew;

namespace Delivery
{
    public class DamageResult : Result
    {
        public DamagePack DamagePack {get; set;}
        public DamageResult(DamagePack damagePack) {
            DamagePack = damagePack;
        }
        public override void Apply(I_EntityManager owner, I_EntityManager target, DeliveryPack pack, List<Result> results, Dictionary<Delivery_Pack_Shifts, AttributeShift> shifts) {
            pack.AddDamage(DamagePack);
        }
    }
}