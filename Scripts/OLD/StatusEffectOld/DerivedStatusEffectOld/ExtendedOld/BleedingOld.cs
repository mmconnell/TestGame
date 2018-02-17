using Enums;
using Enums.CharacterStatus;
using Enums.Damage;

public class BleedingOld : DerivedStatusEffectOld
{
    public BleedingOld() : base()
    {
        DamagePack damagePack = new PercentBasedDamage(DamageTypes.PIERCING, PercentOfDamage.MAX_HEALTH, 5, false);
        AddBaseStatusEffect(new DamageOverTimeStatusEffectOld(damagePack));
        AddBaseStatusEffect(new CharacterAttributeStatusEffectOld(CharacterAttributes.PIERCING_RESISTANCE, 15, Character_Attribute_Shift_Type.DIVISOR));
    }
}