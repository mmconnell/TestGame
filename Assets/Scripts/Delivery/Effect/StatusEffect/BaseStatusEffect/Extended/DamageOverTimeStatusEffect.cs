using Delivery;
using Manager;

public class DamageOverTimeStatusEffect : I_BaseStatusEffect
{
    public DamagePack DamagePack { get; set; }
    public DerivedStatusEffect DerivedStatusEffect { get; set; }
    private DeliveryResult deliveryResult;

    public DamageOverTimeStatusEffect(DerivedStatusEffect derivedStatusEffect, DamagePack damagePack) : base()
    {
        DamagePack = damagePack;
        DerivedStatusEffect = derivedStatusEffect;
        deliveryResult = new DeliveryResult();
    }

    public void Apply()
    {
        EventManager.StartListening(DerivedStatusEffect.target.gameObject, "TURN_START", TurnStart);
    }

    public void Remove()
    {
        EventManager.StopListening(DerivedStatusEffect.target.gameObject, "TURN_START", TurnStart);
    }

    public void End()
    {
        Remove();
    }

    public void TurnStart()
    {
        DamagePack.Apply(DerivedStatusEffect.owner, DerivedStatusEffect.target, deliveryResult);
        DeliveryManager.ApplyResult(deliveryResult);
        deliveryResult.Get(DerivedStatusEffect.target).DamageDone.Clear();
    }
}
