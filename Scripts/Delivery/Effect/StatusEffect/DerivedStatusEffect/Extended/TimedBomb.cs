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

    public TimedBomb(ToolManager owner, ToolManager target) : base(owner, target)
    {
        if (statusEffects == null)
        {
            statusEffects = new List<I_BaseStatusEffect>();
            PriorityDeliveryPack dp = new PriorityDeliveryPack();
            dp.AddEffect(new DamagePack(new SimpleDamageType(Damage_Type_Enum.FIRE), new FlatNumber(100)), 1);

            PriorityDeliveryPack innerDp = new PriorityDeliveryPack();
            dp.AddEffect(new SubDeliveryPack(innerDp, false), 2);
            innerDp.AreaEffect = new SimpleAreaCircle2D(new FlatNumber(5), true);
            innerDp.AddEffect(new DamagePack(new SimpleDamageType(Damage_Type_Enum.BLUDGEONING), new FlatNumber(50)), 1);

            statusEffects.Add(new DelayedStatusEffect(dp));
        }
        
        foreach (I_BaseStatusEffect bse in statusEffects)
        {
            AddBaseStatusEffect(bse);
        }
    }

    public override I_DerivedStatus Clone(ToolManager owner, ToolManager target)
    {
        return new TimedBomb(owner, target);
    }
}
