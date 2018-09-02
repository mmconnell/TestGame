using EnumsNew;
using Manager;
using System.Collections.Generic;
using UnityEngine;

namespace DeliverySystem
{
    public class EffectResult : I_Result
    {
        public StatusEffect EffectPack {get; set;}

        public EffectResult(StatusEffect effectPack) {
            EffectPack = effectPack;
        }

        public void Apply(ToolManager owner, ToolManager target, List<I_Result> results)
        {
            throw new System.NotImplementedException();
        }
    }
}