using EnumsNew;

namespace Delivery
{
    public class FlatDamage : DamagePack
    {
        private int Amount { get; set; }

        public FlatDamage(Damage_Type_Enum damageType, int amount) : base(damageType)
        {
            Amount = amount;
        }

        public int GetAmount()
        {
            return Amount;
        }

        public override int GetAmount(I_EntityManager target, I_EntityManager owner)
        {
            return Amount;
        }

        public override string DamagePackType()
        {
            return "FlatDamage";
        }
    }
}