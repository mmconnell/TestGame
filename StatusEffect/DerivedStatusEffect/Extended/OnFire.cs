using Enums;
using Enums.Damage;
using Enums.CharacterStatus;

public class OnFire : DerivedStatusEffect
{
   public OnFire() : base()
    {
        DamagePack damagePack = new LevelBasedDamage(DamageTypes.FIRE, new FlatDamage(DamageTypes.FIRE, 10), false);
        AddBaseStatusEffect(new DamageOverTimeStatusEffect(damagePack));
        AddBaseStatusEffect(new CharacterAttributeStatusEffect(CharacterAttributes.FIRE_RESISTANCE, 15, Character_Attribute_Shift_Type.DIVISOR));
        AddBaseStatusEffect(new CharacterAttributeStatusEffect(CharacterAttributes.COLD_RESISTANCE, 15, Character_Attribute_Shift_Type.MULTIPLIER));
    }
}