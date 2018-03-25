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
        ((CharacterManager)InformationManager.GetManager(DerivedStatusEffect.target)).Apply(DeliveryPack, ((CharacterManager)InformationManager.GetManager(DerivedStatusEffect.owner)));
    }

    public void Remove(){}
}
