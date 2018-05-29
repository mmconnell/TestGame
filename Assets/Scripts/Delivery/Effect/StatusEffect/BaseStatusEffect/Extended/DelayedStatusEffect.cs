using Delivery;

public class DelayedStatusEffect : I_BaseStatusEffect
{
    public DeliveryPack DeliveryPack { get; set; }
    public DerivedStatusEffect DerivedStatusEffect { get; set; }

    public DelayedStatusEffect(DerivedStatusEffect derivedStatusEffect, DeliveryPack deliveryPack)
    {
        DeliveryPack = deliveryPack;
        DerivedStatusEffect = derivedStatusEffect;
    }

    public void Apply(){}

    public void End()
    {
        DeliveryManager.Run(DerivedStatusEffect.owner, new ObjectPosition(DerivedStatusEffect.gameObject), DeliveryPack);
    }

    public void Remove(){}
}
