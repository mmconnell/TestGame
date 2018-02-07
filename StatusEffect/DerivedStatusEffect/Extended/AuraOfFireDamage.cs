using Enums;

public class AuraOfFireDamage : DerivedStatusEffect
{
    public AuraOfFireDamage() : base()
    {
        AddBaseStatusEffect(new AuraStatusEffect(new EffectPack(100, DerivedStatusEffects.ON_FIRE, Enums.Persistance.COMBAT, -1), TeamTarget.ENEMIES, 1));
    }
}
