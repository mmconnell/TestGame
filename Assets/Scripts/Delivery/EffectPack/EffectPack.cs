using Enums;
using System.Collections.Generic;
using UnityEngine;

namespace Delivery
{
    public class EffectPack {
        public List<DamagePack> Damages { get; set; }
        public List<StatusEffect> StatusEffects { get; set; }
        public I_AreaEffect AreaEffect { get; set; }

        public EffectPack(List<DamagePack> damages, List<StatusEffect> statusEffects, I_AreaEffect areaEffect)
        {
            Damages = damages ?? new List<DamagePack>();
            StatusEffects = statusEffects ?? new List<StatusEffect>();
            AreaEffect = areaEffect;
        }

        public void Apply(I_EntityManager owner, I_EntityManager target)
        {

        }
    }
}