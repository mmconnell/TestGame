using EnumsNew;
using Delivery;
using Utility;

public class OnFire : DerivedStatusEffect
{
    public override void Start()
    {
        DamagePack damagePack = new DamagePack(new SimpleDamageType(Damage_Type_Enum.FIRE), new LevelBasedNumber(new FlatNumber(10), false));
        AddBaseStatusEffect(new DamageOverTimeStatusEffect(this, damagePack));
        AddBaseStatusEffect(new ResistanceStatusEffect(this, Damage_Type_Enum.FIRE, -15));
        AddBaseStatusEffect(new ResistanceStatusEffect(this, Damage_Type_Enum.COLD, 15));
        base.Start();
    }
}
