using EnumsNew;
using System.Collections.Generic;

namespace Delivery
{
    public class EffectResult : Result
    {
        public EffectPack EffectPack {get; set;}
        public EffectResult(EffectPack effectPack) {
            EffectPack = effectPack;
        }
        public override void Apply(I_EntityManager owner, I_EntityManager target, DeliveryPack pack, List<Result> results, Dictionary<Delivery_Pack_Shifts, AttributeShift> shifts) {
            pack.AddEffect(EffectPack);
        }        
    }

}