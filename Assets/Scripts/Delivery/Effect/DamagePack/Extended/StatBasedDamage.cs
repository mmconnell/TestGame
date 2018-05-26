using EnumsNew;
using UnityEngine;

namespace Delivery
{
    public class StatBasedDamage : DamagePack
    {
        public DamagePack DamagePack { get; private set; }
        public bool SourceIsOwner { get; private set; }
        public Character_Stat CharacterStat { get; private set; }

        public StatBasedDamage(Damage_Type_Enum damageType, DamagePack damagePack, Character_Stat characterStat, bool sourceIsOwner) : base(damageType)
        {
            if (damagePack.Contains(DamagePackType()))
            {
                throw new System.Exception("StatBasedDamage is not an allowable argument");
            }
            DamagePack = damagePack;
            CharacterStat = characterStat;
            SourceIsOwner = sourceIsOwner;
        }

        public override int GetAmount(GameObject owner, GameObject target)
        {
            //I_EntityManager source = SourceIsOwner ? owner : target;
            double value = DamagePack.GetAmount(owner, target);
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