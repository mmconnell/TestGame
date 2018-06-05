using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Utility;

namespace Delivery
{
    public class FirePulse : DerivedStatusEffect
    {
        public static FirePulse Cloner = new FirePulse();
        private static List<I_BaseStatusEffect> statusEffects;

        private FirePulse() : base() { }

        public FirePulse(ToolManager owner, ToolManager target, int duration) : base(owner, target, duration)
        {
            if (statusEffects == null)
            {
                statusEffects = new List<I_BaseStatusEffect>();
                statusEffects.Add(new EffectOverTime(
                new PulseEffect(
                    new DamagePack(new SimpleDamageType(EnumsNew.Damage_Type_Enum.FIRE), new RangeNumber(new FlatNumber(10), new FlatNumber(20))),
                    .1f, .1f, .1f, 5f, .1f, Resources.Load("blue", typeof(Material)) as Material, false)));
            }

            foreach (I_BaseStatusEffect bse in statusEffects)
            {
                AddBaseStatusEffect(bse);
            }

            Initiate();
            Enable();
        }

        public override DerivedStatusEffect Clone(ToolManager owner, ToolManager target, int duration)
        {
            return Create(owner, target, duration);
        }

        public static FirePulse Create(ToolManager owner, ToolManager target, int duration)
        {
            return new FirePulse(owner, target, duration);
        }
    }
}
