using Enums.CharacterStat;
using EnumsNew;

namespace Delivery
{
    public class StatBasedDamage : DamagePack
    {
        public DamagePack DamagePack { get; private set; }
        public bool SourceIsOwner { get; private set; }
        public CharacterStat CharacterStat { get; private set; }

        public StatBasedDamage(Damage_Type_Enum damageType, DamagePack damagePack, CharacterStat characterStat, bool sourceIsOwner) : base(damageType)
        {
            if (damagePack.Contains(DamagePackType()))
            {
                throw new System.Exception("StatBasedDamage is not an allowable argument");
            }
            DamagePack = damagePack;
            CharacterStat = characterStat;
            SourceIsOwner = sourceIsOwner;
        }

        public override int GetAmount(I_EntityManager target, I_EntityManager owner)
        {
            I_EntityManager source = SourceIsOwner ? owner : target;
            double value = DamagePack.GetAmount(target, owner);
            //value *= source.GetStatBonus(CharacterStat);
            return (int)value;
        }

        public override string DamagePackType()
        {
            return "StatBasedDamage";
        }

        public override bool Contains(string type)
        {
            return base.Contains(type) || DamagePack.Contains(type);
        }
    }
}