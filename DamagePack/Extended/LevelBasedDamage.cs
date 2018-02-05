using Enums.Damage;

public class LevelBasedDamage : DamagePack
{
    private DamagePack DamagePack { get; set; }
    private bool SourceIsOwner { get; set; }

    public LevelBasedDamage(DamageType damageType, DamagePack damagePack, bool sourceIsOwner) : base(damageType)
    {
        if(damagePack is LevelBasedDamage)
        {
            throw new System.Exception("LevelBasedDamage is not an acceptable argument");
        }
        DamagePack = damagePack;
        SourceIsOwner = sourceIsOwner;
    }

    public override int GetAmount(CharacterManager target, CharacterManager owner)
    {
        CharacterManager source = SourceIsOwner ? owner : target;
        return DamagePack.GetAmount(target, owner) * source.Level;
    }
}
