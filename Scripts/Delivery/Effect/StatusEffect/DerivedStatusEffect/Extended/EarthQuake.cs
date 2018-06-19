using Delivery;
using Manager;
using System.Collections.Generic;
using Utility;

public class EarthQuake : DerivedStatusEffect
{
    public static EarthQuake Cloner = new EarthQuake();
    private static List<I_BaseStatusEffect> statusEffects;

    private EarthQuake() : base() { }

    public EarthQuake(ToolManager owner, ToolManager target) : base(owner, target)
    {
        if (statusEffects == null)
        {
            statusEffects = new List<I_BaseStatusEffect>();
            I_DeliveryPack deliveryPack = new PriorityDeliveryPack
            {
                AreaEffect = new SimpleAreaCircle2D(new FlatNumber(2), true),
                EffectMap = new Dictionary<int, List<I_Effect>>
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
    }

    public override I_DerivedStatus Clone(ToolManager owner, ToolManager target)
    {
        return new EarthQuake(owner, target);
    }
}
