using Manager;
using System.Collections.Generic;

namespace DeliverySystem
{
    public class FirePulse : DerivedStatusEffect
    {
        public static FirePulse Cloner = new FirePulse();
        private static List<I_BaseStatusEffect> statusEffects;

        private FirePulse() : base() { }

        public FirePulse(ToolManager owner, ToolManager target) : base(owner, target)
        {
            if (statusEffects == null)
            {
                /*statusEffects = new List<I_BaseStatusEffect>
                {
                    new EffectOverTime(
                        new PulseEffect(
                            new DamagePack(new SimpleDamageType(EnumsNew.Damage_Type_Enum.FIRE), new RangeNumber(new FlatNumber(10), new FlatNumber(20))),
                                .1f, .1f, .1f, 5f, .1f, Resources.Load("blue", typeof(Material)) as Material, false
                        )
                    )
                };*/
            }

            foreach (I_BaseStatusEffect bse in statusEffects)
            {
                AddBaseStatusEffect(bse);
            }
        }

        public override I_DerivedStatus Clone(ToolManager owner, ToolManager target)
        {
            return new FirePulse(owner, target);
        }
    }
}
