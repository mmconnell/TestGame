namespace Enums.Damage
{
    public class Damages
    {
        public static Damage PHYSICAL = new Damage(Damage_Enum.PHYSICAL);
        public static Damage PIERCING = new Damage(Damage_Enum.PIERCING, PHYSICAL);
        public static Damage BLUDGEONING = new Damage(Damage_Enum.BLUDGEONING, PHYSICAL);
        public static Damage SLASHING = new Damage(Damage_Enum.SLASHING, PHYSICAL);

        public static Damage MAGICAL = new Damage(Damage_Enum.MAGICAL);
        public static Damage FIRE = new Damage(Damage_Enum.FIRE, MAGICAL);
        public static Damage SHOCK = new Damage(Damage_Enum.SHOCK, MAGICAL);
        public static Damage COLD = new Damage(Damage_Enum.COLD, MAGICAL);
        public static Damage POISON = new Damage(Damage_Enum.POISON, MAGICAL);

        public static Damage UNTYPED = new Damage(Damage_Enum.UNTYPED);
    }
}