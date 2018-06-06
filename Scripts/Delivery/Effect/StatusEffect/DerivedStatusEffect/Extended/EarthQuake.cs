using Delivery;
using Manager;
using System.Collections.Generic;
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
            DeliveryPack deliveryPack = new DeliveryPack
            {
                AreaEffect = new SimpleAreaCircle2D(new FlatNumber(2), true),
                EffectMap = new SortedDictionary<int, List<I_Effect>>
                {
                    {
                        1, new List<I_Effect>
                        {
                            new DamagePack(new SimpleDamageType(EnumsNew.Damage_Type_Enum.SHOCK), new RangeNumber(new FlatNumber(3), new FlatNumber(20)))
                        }
                    }
                }
            };
            statusEffects.Add(new EffectOverTime(new SubDeliveryPack(deliveryPack, false)));
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
