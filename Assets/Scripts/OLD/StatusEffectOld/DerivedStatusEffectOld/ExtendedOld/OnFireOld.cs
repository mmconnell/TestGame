using Enums;
using Enums.Damage;
using Enums.CharacterStatus;

public class OnFireOld : DerivedStatusEffectOld
{
   public OnFireOld() : base()
    {
        DamagePackOld damagePack = new LevelBasedDamageOld(DamageTypes.FIRE, new FlatDamageOld(DamageTypes.FIRE, 10), false);
        AddBaseStatusEffect(new DamageOverTimeStatusEffectOld(damagePack));
        AddBaseStatusEffect(new CharacterAttributeStatusEffectOld(CharacterAttributes.FIRE_RESISTANCE, 15, Character_Attribute_Shift_Type.DIVISOR));
        AddBaseStatusEffect(new CharacterAttributeStatusEffectOld(CharacterAttributes.COLD_RESISTANCE, 15, Character_Attribute_Shift_Type.MULTIPLIER));
    }
}