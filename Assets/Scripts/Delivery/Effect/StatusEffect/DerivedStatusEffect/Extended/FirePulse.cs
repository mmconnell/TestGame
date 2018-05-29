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
        public override void Start()
        {
            BaseStatusEffects.Add(new EffectOverTime(
                this, new PulseEffect(
                    new DamagePack(new SimpleDamageType(EnumsNew.Damage_Type_Enum.FIRE), new FlatNumber(10)),
                    .1f, .1f, .1f, 5f, .1f, Resources.Load("blue", typeof(Material)) as Material, false)));
            base.Start();
        }
    }
}
