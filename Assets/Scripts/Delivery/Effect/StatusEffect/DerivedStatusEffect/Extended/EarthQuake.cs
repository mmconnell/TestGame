using Delivery;
using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

public class EarthQuake : DerivedStatusEffect
{
    public static EarthQuake Cloner = new EarthQuake();
    private static List<I_BaseStatusEffect> statusEffects;

    private EarthQuake() : base() { }

    public EarthQuake(ToolManager owner, ToolManager target, int duration) : base(owner, target, duration)
    {
        if (statusEffects == null)
        {
            statusEffects = new List<I_BaseStatusEffect>();
            DeliveryPack deliveryPack = new DeliveryPack();
            deliveryPack.AreaEffect = new SimpleAreaCircle2D(new FlatNumber(2), true);
            deliveryPack.AddEffect(new DamagePack(new SimpleDamageType(EnumsNew.Damage_Type_Enum.SHOCK), new RangeNumber(new FlatNumber(3), new FlatNumber(20))), 1);
            statusEffects.Add(new EffectOverTime(new SubDeliveryPack(deliveryPack)));
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

    public static EarthQuake Create(ToolManager owner, ToolManager target, int duration)
    {
        return new EarthQuake(owner, target, duration);
    }
}
