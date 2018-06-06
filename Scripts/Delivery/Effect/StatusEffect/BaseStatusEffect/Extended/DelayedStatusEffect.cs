using Delivery;
using Manager;

public class DelayedStatusEffect : I_BaseStatusEffect
{
    public DeliveryPack DeliveryPack { get; set; }

    public DelayedStatusEffect(DeliveryPack deliveryPack)
    {
        DeliveryPack = deliveryPack;
    }

    public void Apply(DerivedStatusEffect dse){}

    public void End(DerivedStatusEffect dse)
    {
        DeliveryManager.Run(dse.owner, new ObjectPosition(dse.target), DeliveryPack);
    }

    public void Remove(DerivedStatusEffect dse){}

    public void Trigger(DerivedStatusEffect dse, StatusEnum statusEnum){}

    private StatusEnum[] statusEnums = new StatusEnum[] {};
    public StatusEnum[] GetStatusEnums()
    {
        return statusEnums;
    }
}
