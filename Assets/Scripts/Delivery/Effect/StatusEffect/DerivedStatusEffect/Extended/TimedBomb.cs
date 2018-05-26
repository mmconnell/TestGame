using Delivery;

public class TimedBomb : DerivedStatusEffect
{
    public override void Start()
    {
        DeliveryPack dp = new DeliveryPack();
        //dp.AddDamage(new FlatDamage(Damage_Type_Enum.BLUDGEONING, 100));
        //dp.AddDamage(new Burst(Damage_Type_Enum.BLUDGEONING, new FlatDamage(Damage_Type_Enum.BLUDGEONING, 50), 5, Team_Target.ENEMIES));
        AddBaseStatusEffect(new DelayedStatusEffect(this, dp));
        base.Start();
    }
}
