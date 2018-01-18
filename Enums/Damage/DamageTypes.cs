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
    }
}