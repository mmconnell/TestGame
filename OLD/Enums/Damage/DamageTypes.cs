using Enums.CharacterStatus;
using Enums.Trigger;
using System.Collections.Generic;

namespace Enums.Damage
{
    public class DamageTypes
    {
        public static DamageType PHYSICAL = new DamageType(Damage_Type_Enum.PHYSICAL);
        public static DamageType PIERCING = new DamageType(Damage_Type_Enum.PIERCING, PHYSICAL);
        public static DamageType BLUDGEONING = new DamageType(Damage_Type_Enum.BLUDGEONING, PHYSICAL);
        public static DamageType SLASHING = new DamageType(Damage_Type_Enum.SLASHING, PHYSICAL);

        public static DamageType MAGICAL = new DamageType(Damage_Type_Enum.MAGICAL);
        public static DamageType FIRE = new DamageType(Damage_Type_Enum.FIRE, MAGICAL);
        public static DamageType SHOCK = new DamageType(Damage_Type_Enum.SHOCK, MAGICAL);
        public static DamageType COLD = new DamageType(Damage_Type_Enum.COLD, MAGICAL);
        public static DamageType POISON = new DamageType(Damage_Type_Enum.POISON, MAGICAL);

        public static DamageType UNTYPED = new DamageType(Damage_Type_Enum.UNTYPED);

        public static DamageType HEALING = new DamageType(Damage_Type_Enum.HEALING);

        public static readonly Dictionary<Damage_Type_Enum, DamageTriggerHolder> DamageToTriggers
             = new Dictionary<Damage_Type_Enum, DamageTriggerHolder>
         {
                 {PHYSICAL.DamageValue, new DamageTriggerHolder(CharacterTriggers.DEAL_PHYSICAL, CharacterTriggers.RECEIVE_PHYSICAL)},
                 {PIERCING.DamageValue, new DamageTriggerHolder(CharacterTriggers.DEAL_PIERCING, CharacterTriggers.RECEIVE_PIERCING)},
                 {BLUDGEONING.DamageValue, new DamageTriggerHolder(CharacterTriggers.DEAL_BLUDGEONING, CharacterTriggers.RECEIVE_BLUDGEONING)},
                 {SLASHING.DamageValue, new DamageTriggerHolder(CharacterTriggers.DEAL_SLASHING, CharacterTriggers.RECEIVE_SLASHING)},
                 {MAGICAL.DamageValue, new DamageTriggerHolder(CharacterTriggers.DEAL_MAGICAL, CharacterTriggers.RECEIVE_MAGICAL)},
                 {FIRE.DamageValue, new DamageTriggerHolder(CharacterTriggers.DEAL_FIRE, CharacterTriggers.RECEIVE_FIRE)},
                 {SHOCK.DamageValue, new DamageTriggerHolder(CharacterTriggers.DEAL_SHOCK, CharacterTriggers.RECEIVE_SHOCK)},
                 {COLD.DamageValue, new DamageTriggerHolder(CharacterTriggers.DEAL_COLD, CharacterTriggers.RECEIVE_COLD)},
                 {POISON.DamageValue, new DamageTriggerHolder(CharacterTriggers.DEAL_POISON, CharacterTriggers.RECEIVE_POISON)},
                 {UNTYPED.DamageValue, new DamageTriggerHolder(CharacterTriggers.DEAL_UNTYPED, CharacterTriggers.RECEIVE_UNTYPED)},
                 {HEALING.DamageValue, new DamageTriggerHolder(CharacterTriggers.HEAL, CharacterTriggers.HEALED)}
         };

        public static readonly Dictionary<Damage_Type_Enum, CharacterAttribute> DamageToResistances
            = new Dictionary<Damage_Type_Enum, CharacterAttribute>
            {
            {PHYSICAL.DamageValue, CharacterAttributes.PHYSICAL_RESISTANCE},
                 {PIERCING.DamageValue, CharacterAttributes.BLUDGEONING_RESISTANCE},
                 {BLUDGEONING.DamageValue, CharacterAttributes.BLUDGEONING_RESISTANCE},
                 {SLASHING.DamageValue, CharacterAttributes.SLASHING_RESISTANCE},
                 {MAGICAL.DamageValue, CharacterAttributes.MAGICAL_RESISTANCE},
                 {FIRE.DamageValue, CharacterAttributes.FIRE_RESISTANCE},
                 {SHOCK.DamageValue, CharacterAttributes.SHOCK_RESISTANCE},
                 {COLD.DamageValue, CharacterAttributes.COLD_RESISTANCE},
                 {POISON.DamageValue, CharacterAttributes.POISON_RESISTANCE},
                 {UNTYPED.DamageValue, null},
                 {HEALING.DamageValue, CharacterAttributes.HEALING_RESISTANCE}
            };
    }
}