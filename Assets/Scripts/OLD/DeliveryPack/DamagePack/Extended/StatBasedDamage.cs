using Enums.CharacterStat;
using Enums.Damage;

public class StatBasedDamageOld : DamagePackOld
{
    public DamagePackOld DamagePack { get; private set; }
    public bool SourceIsOwner { get; private set; }
    public CharacterStat CharacterStat { get; private set; }

    public StatBasedDamageOld(DamageType damageType, DamagePackOld damagePack, CharacterStat characterStat, bool sourceIsOwner) : base(damageType)
    {
        if(damagePack.Contains(DamagePackType()))
        {
            throw new System.Exception("StatBasedDamage is not an allowable argument");
        }
        DamagePack = damagePack;
        CharacterStat = characterStat;
        SourceIsOwner = sourceIsOwner;
    }

    public override int GetAmount(CharacterManager target, CharacterManager owner)
    {
        //CharacterManager source = SourceIsOwner ? owner : target;
        double value = DamagePack.GetAmount(target, owner);
       // value *= source.GetStatBonus(CharacterStat);
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
