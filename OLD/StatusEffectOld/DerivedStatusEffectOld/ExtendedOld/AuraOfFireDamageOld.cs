using Enums;

public class AuraOfFireDamageOld : DerivedStatusEffectOld
{
    public AuraOfFireDamageOld() : base()
    {
        AddBaseStatusEffect(new AuraStatusEffectOld(new EffectPack(100, DerivedStatusEffectsOld.ON_FIRE, Enums.Persistance.COMBAT, -1), Team_Target.ENEMIES, 1));
    }
}
