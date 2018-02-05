using Enums.CharacterStat;
using Enums.Damage;

public class StatBasedDamage : DamagePack
{
    public DamagePack DamagePack { get; private set; }
    public bool SourceIsOwner { get; private set; }
    public CharacterStat CharacterStat { get; private set; }

    public StatBasedDamage(DamageType damageType, DamagePack damagePack, CharacterStat characterStat, bool sourceIsOwner) : base(damageType)
    {
        if(damagePack is StatBasedDamage)
        {
            throw new System.Exception("StatBasedDamage is not an allowable argument");
        }
        DamagePack = damagePack;
        CharacterStat = characterStat;
        SourceIsOwner = sourceIsOwner;
    }

    public override int GetAmount(CharacterManager target, CharacterManager owner)
    {
        CharacterManager source = SourceIsOwner ? owner : target;
        double value = DamagePack.GetAmount(target, owner);
        value *= source.GetStatBonus(CharacterStat);
        return (int)value;
    } 
}
