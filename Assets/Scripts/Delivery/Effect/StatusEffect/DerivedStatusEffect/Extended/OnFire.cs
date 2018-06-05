using EnumsNew;
using Delivery;
using Utility;
using Manager;
using System.Collections.Generic;

public class OnFire : DerivedStatusEffect
{
    public static OnFire Cloner = new OnFire();
    private static List<I_BaseStatusEffect> statusEffects;

    private OnFire() : base() { }

    public OnFire(ToolManager owner, ToolManager target, int duration) : base(owner, target, duration)
    {
        if (statusEffects == null)
        {
            statusEffects = new List<I_BaseStatusEffect>();
            DamagePack damagePack = new DamagePack(new SimpleDamageType(Damage_Type_Enum.FIRE), new RangeNumber(new FlatNumber(10), new FlatNumber(20)));
            statusEffects.Add(new DamageOverTimeStatusEffect(damagePack));
            statusEffects.Add(new ResistanceStatusEffect(Damage_Type_Enum.FIRE, -15));
            statusEffects.Add(new ResistanceStatusEffect(Damage_Type_Enum.COLD, 15));
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

    public static OnFire Create(ToolManager owner, ToolManager target, int duration)
    {
        return new OnFire(owner, target, duration);
    }
}
