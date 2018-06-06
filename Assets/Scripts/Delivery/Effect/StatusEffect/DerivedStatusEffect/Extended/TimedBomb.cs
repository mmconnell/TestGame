using Delivery;
using EnumsNew;
using Manager;
using System.Collections.Generic;
using Utility;

public class TimedBomb : DerivedStatusEffect
{
    public static TimedBomb Cloner = new TimedBomb();
    private static List<I_BaseStatusEffect> statusEffects;

    private TimedBomb() : base() { }

    public TimedBomb(ToolManager owner, ToolManager target, int duration) : base(owner, target, duration)
    {
        if (statusEffects == null)
        {
            statusEffects = new List<I_BaseStatusEffect>();
            DeliveryPack dp = new DeliveryPack();
            dp.AddEffect(new DamagePack(new SimpleDamageType(Damage_Type_Enum.FIRE), new FlatNumber(100)), 1);

            DeliveryPack innerDp = new DeliveryPack();
            dp.AddEffect(new SubDeliveryPack(innerDp, false), 2);
            innerDp.AreaEffect = new SimpleAreaCircle2D(new FlatNumber(5), true);
            innerDp.AddEffect(new DamagePack(new SimpleDamageType(Damage_Type_Enum.BLUDGEONING), new FlatNumber(50)), 1);

            statusEffects.Add(new DelayedStatusEffect(dp));
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

    public static TimedBomb Create(ToolManager owner, ToolManager target, int duration)
    {
        return new TimedBomb(owner, target, duration);
    }
}
