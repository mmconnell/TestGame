using Enums.Damage;

public class TimedBomb : DerivedStatusEffect
{
    public override void Start()
    {
        DeliveryPack dp = new DeliveryPack();
        dp.Add(new FlatDamage(DamageTypes.BLUDGEONING, 100));
        dp.Add(new Burst(DamageTypes.BLUDGEONING, new FlatDamage(DamageTypes.BLUDGEONING, 50), 5, Enums.TeamTarget.ENEMIES));
        AddBaseStatusEffect(new DelayedStatusEffect(this, dp));
        base.Start();
    }
}
