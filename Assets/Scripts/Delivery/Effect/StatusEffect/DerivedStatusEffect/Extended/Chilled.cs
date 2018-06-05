using Delivery;
using EnumsNew;
using Manager;
using System.Collections.Generic;
using Utility;

public class Chilled : DerivedStatusEffect
{
    public static Chilled Cloner = new Chilled();
    private static List<I_BaseStatusEffect> statusEffects;

    private Chilled() : base(){}

    public Chilled(ToolManager owner, ToolManager target, int duration) : base(owner, target, duration)
    {
        if (statusEffects == null)
        {
            statusEffects = new List<I_BaseStatusEffect>();
            statusEffects.Add(new DamageOverTimeStatusEffect(new DamagePack(new SimpleDamageType(Damage_Type_Enum.COLD), new RangeNumber(new FlatNumber(5), new FlatNumber(15)))));
            statusEffects.Add(new ResistanceStatusEffect(Damage_Type_Enum.COLD, -15));
            statusEffects.Add(new ResistanceStatusEffect(Damage_Type_Enum.FIRE, 15));
        }

        foreach (I_BaseStatusEffect bse in statusEffects)
        {
            AddBaseStatusEffect(bse);
        }

        Initiate();
        Enable();
    }

    public override DerivedStatusEffect Clone(ToolManager owner, ToolManager target, int duration)
    {
        return Create(owner, target, duration);
    }

    public static Chilled Create(ToolManager owner, ToolManager target, int duration)
    {
        return new Chilled(owner, target, duration);
    }
}
