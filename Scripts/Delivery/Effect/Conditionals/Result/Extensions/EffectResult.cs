using EnumsNew;
using System.Collections.Generic;
using UnityEngine;

namespace Delivery
{
    public class EffectResult : Result
    {
        public StatusEffect EffectPack {get; set;}

        public EffectResult(StatusEffect effectPack) {
            EffectPack = effectPack;
        }

        public override void Apply(GameObject owner, GameObject target, I_DeliveryPack pack, I_DeliveryPack newPack, List<Result> results, Dictionary<Delivery_Pack_Shifts, NumberShift> shifts) {
            //newPack.AddEffect(EffectPack);
        }        
    }
}