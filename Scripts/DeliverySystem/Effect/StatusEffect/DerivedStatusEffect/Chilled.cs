using DeliverySystem;
using EnumsNew;
using Manager;
using System.Collections.Generic;
using Utility;

namespace DeliverySystem
{
    public class Chilled : DerivedStatusEffect
    {
        public static Chilled Cloner = new Chilled();
        private static List<I_BaseStatusEffect> statusEffects;

        private Chilled() : base() { }

        public Chilled(ToolManager owner, ToolManager target) : base(owner, target)
        {
            if (statusEffects == null)
            {
                statusEffects = new List<I_BaseStatusEffect>
                {
                    new EffectOverTime(new DamagePack(new SimpleDamageType(Damage_Type_Enum.COLD), new StatBasedNumber(new FlatNumber(10), Character_Attribute_Enum.STRENGTH, .1f, true))),
                    new ResistanceStatusEffect(Damage_Type_Enum.COLD, -15),
                    new ResistanceStatusEffect(Damage_Type_Enum.FIRE, 15),
                    new AttributeStatusEffect(Character_Attribute_Enum.STRENGTH, 10)
                };
            }

            foreach (I_BaseStatusEffect bse in statusEffects)
            {
                AddBaseStatusEffect(bse);
            }
        }

        public override I_DerivedStatus Clone(ToolManager owner, ToolManager target)
        {
            return new Chilled(owner, target);
        }
    }
}