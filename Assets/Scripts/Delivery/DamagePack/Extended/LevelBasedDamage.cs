using EnumsNew;

namespace Delivery
{
    public class LevelBasedDamage : DamagePack
    {
        private DamagePack DamagePack { get; set; }
        private bool SourceIsOwner { get; set; }

        public LevelBasedDamage(Damage_Type_Enum damageType, DamagePack damagePack, bool sourceIsOwner) : base(damageType)
        {
            if (damagePack.Contains(DamagePackType()))
            {
                throw new System.Exception("LevelBasedDamage is not an acceptable argument");
            }
            DamagePack = damagePack;
            SourceIsOwner = sourceIsOwner;
        }

        public override int GetAmount(I_EntityManager target, I_EntityManager owner)
        {
            I_EntityManager source = SourceIsOwner ? owner : target;
            return DamagePack.GetAmount(source, owner);
        }

        public override string DamagePackType()
        {
            return "LevelBasedDamage";
        }

        public override bool Contains(string type)
        {
            return base.Contains(type) || DamagePack.Contains(type);
        }
    }
}