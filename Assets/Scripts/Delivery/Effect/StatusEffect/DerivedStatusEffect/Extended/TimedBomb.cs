using Delivery;
using EnumsNew;
using Utility;

public class TimedBomb : DerivedStatusEffect
{
    public override void Start()
    {
        DeliveryPack dp = new DeliveryPack();
        dp.AddEffect(new DamagePack(new SimpleDamageType(Damage_Type_Enum.FIRE), new FlatNumber(100)), 1);

        DeliveryPack innerDp = new DeliveryPack();
        dp.AddEffect(new SubDeliveryPack(innerDp), 2);
        innerDp.AreaEffect = new SimpleAreaCircle2D(new FlatNumber(5), true);
        innerDp.AddEffect(new DamagePack(new SimpleDamageType(Damage_Type_Enum.BLUDGEONING), new FlatNumber(50)), 1);

        AddBaseStatusEffect(new DelayedStatusEffect(this, dp));
        base.Start();
    }
}
