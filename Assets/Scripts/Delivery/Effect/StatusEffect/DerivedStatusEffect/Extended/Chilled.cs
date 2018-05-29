using Delivery;
using EnumsNew;
using Utility;

public class Chilled : DerivedStatusEffect
{
    public override void Start()
    {
        BaseStatusEffects.Add(new DamageOverTimeStatusEffect(this, new DamagePack(new SimpleDamageType(Damage_Type_Enum.COLD), new FlatNumber(10))));
        BaseStatusEffects.Add(new ResistanceStatusEffect(this, Damage_Type_Enum.COLD, -15));
        BaseStatusEffects.Add(new ResistanceStatusEffect(this, Damage_Type_Enum.FIRE, 15));
        base.Start();
    }
}
