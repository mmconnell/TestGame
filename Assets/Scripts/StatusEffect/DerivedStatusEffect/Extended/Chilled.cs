using Delivery;
using Enums.CharacterStatus;
using EnumsNew;

public class Chilled : DerivedStatusEffect
{
    public override void Start()
    {
        BaseStatusEffects.Add(new DamageOverTimeStatusEffect(this, new FlatDamage(Damage_Type_Enum.COLD, 10)));
        BaseStatusEffects.Add(new CharacterAttributeStatusEffect(this, CharacterAttributes.COLD_RESISTANCE, 50, Character_Attribute_Shift_Type.DIVISOR));
        BaseStatusEffects.Add(new CharacterAttributeStatusEffect(this, CharacterAttributes.FIRE_RESISTANCE, 30, Character_Attribute_Shift_Type.MULTIPLIER));
        base.Start();
    }
}
