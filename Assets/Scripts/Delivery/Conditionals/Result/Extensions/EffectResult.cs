using EnumsNew;
using System.Collections.Generic;

namespace Delivery
{
    public class EffectResult : Result
    {
        public StatusEffect EffectPack {get; set;}

        public EffectResult(StatusEffect effectPack) {
            EffectPack = effectPack;
        }

        public override void Apply(I_EntityManager owner, I_EntityManager target, DeliveryPack pack, DeliveryPack newPack, List<Result> results, Dictionary<Delivery_Pack_Shifts, AttributeShift> shifts) {
            newPack.AddEffect(EffectPack);
        }        
    }
}