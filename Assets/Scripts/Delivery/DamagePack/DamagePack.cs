using EnumsNew;

namespace Delivery
{
    public abstract class DamagePack
    {
        public Damage_Type_Enum DamageType { get; set; }

        public DamagePack(Damage_Type_Enum damageType)
        {
            DamageType = damageType;
        }

        public abstract int GetAmount(I_EntityManager target, I_EntityManager owner);

        public virtual void Apply(CharacterManager target, CharacterManager owner)
        {
            target.TakeDamage(GetAmount(target, owner), DamageType, owner);
        }

        public abstract string DamagePackType();

        public virtual void Respond(CharacterManager target, CharacterManager owner, int amount)
        {
            //owner.Response(target, amount, DamageType);
        }

        public virtual bool Contains(string type)
        {
            return type.Equals(DamagePackType());
        }
    }
}