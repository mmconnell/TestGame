using UnityEngine;
using System.Collections;
using Enums.CharacterStatus;
using Enums.Damage;
using Enums;

public class OnFire2 : DerivedStatusEffect
{
    public override void Start()
    {
        DamagePack damagePack = new LevelBasedDamage(DamageTypes.FIRE, new FlatDamage(DamageTypes.FIRE, 10), false);
        AddBaseStatusEffect(new DamageOverTimeStatusEffect(this, damagePack));
        AddBaseStatusEffect(new CharacterAttributeStatusEffect(this, CharacterAttributes.FIRE_RESISTANCE, 15, Character_Attribute_Shift_Type.DIVISOR));
        AddBaseStatusEffect(new CharacterAttributeStatusEffect(this, CharacterAttributes.COLD_RESISTANCE, 15, Character_Attribute_Shift_Type.MULTIPLIER));
        base.Start();
    }
}
