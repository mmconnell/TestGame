using EnumsNew;
using Delivery;

public class OnFire2 : DerivedStatusEffect
{
    public override void Start()
    {
        DamagePack damagePack = new LevelBasedDamage(Damage_Type_Enum.FIRE, new FlatDamage(Damage_Type_Enum.FIRE, 10), false);
        AddBaseStatusEffect(new DamageOverTimeStatusEffect(this, damagePack));
        AddBaseStatusEffect(new CharacterAttributeStatusEffect(this, Character_Attribute_Enum.FIRE_RESISTANCE, 15, Character_Attribute_Shift_Type.DIVISOR));
        AddBaseStatusEffect(new CharacterAttributeStatusEffect(this, Character_Attribute_Enum.COLD_RESISTANCE, 15, Character_Attribute_Shift_Type.MULTIPLIER));
        base.Start();
    }
}
