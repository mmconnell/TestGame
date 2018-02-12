using Enums.CharacterStatus;
using Enums.Damage;

public class Chilled : DerivedStatusEffect2
{
    public override void Start()
    {
        BaseStatusEffects.Add(new DamageOverTimeStatusEffect2(this, new FlatDamage(DamageTypes.COLD, 10)));
        BaseStatusEffects.Add(new CharacterAttributeStatusEffect2(this, CharacterAttributes.COLD_RESISTANCE, 50, Enums.Character_Attribute_Shift_Type.DIVISOR));
        BaseStatusEffects.Add(new CharacterAttributeStatusEffect2(this, CharacterAttributes.FIRE_RESISTANCE, 30, Enums.Character_Attribute_Shift_Type.MULTIPLIER));
        base.Start();
    }
}
