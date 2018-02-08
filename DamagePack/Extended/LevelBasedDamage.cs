using Enums.Damage;

public class LevelBasedDamage : DamagePack
{
    private DamagePack DamagePack { get; set; }
    private bool SourceIsOwner { get; set; }

    public LevelBasedDamage(DamageType damageType, DamagePack damagePack, bool sourceIsOwner) : base(damageType)
    {
        if(damagePack.Contains(DamagePackType()))
        {
            throw new System.Exception("LevelBasedDamage is not an acceptable argument");
        }
        DamagePack = damagePack;
        SourceIsOwner = sourceIsOwner;
    }

    public override int GetAmount(CharacterManager target, CharacterManager owner)
    {
        CharacterManager source = SourceIsOwner ? owner : target;
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
