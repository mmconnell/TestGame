using Enums;
using Enums.CharacterStatus;
using Enums.Damage;

public class Bleeding : DerivedStatusEffect
{
    public Bleeding() : base()
    {
        DamagePack damagePack = new PercentBasedDamage(DamageTypes.PIERCING, PercentOfDamage.MAX_HEALTH, 5, false);
        AddBaseStatusEffect(new DamageOverTimeStatusEffect(damagePack));
        AddBaseStatusEffect(new CharacterAttributeStatusEffect(CharacterAttributes.PIERCING_RESISTANCE, 15, Character_Attribute_Shift_Type.DIVISOR));
    }
}