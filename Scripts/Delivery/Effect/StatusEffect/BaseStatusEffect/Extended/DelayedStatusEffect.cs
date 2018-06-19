using Delivery;
using Manager;

public class DelayedStatusEffect : I_BaseStatusEffect
{
    public I_DeliveryPack DeliveryPack { get; set; }

    public DelayedStatusEffect(I_DeliveryPack deliveryPack)
    {
        DeliveryPack = deliveryPack;
    }

    public void Apply(DerivedStatusEffect dse){}

    public void End(DerivedStatusEffect dse)
    {
        DeliveryUtility.Deliver(DeliveryPack, dse.owner, dse.target.position);
    }

    public void Remove(DerivedStatusEffect dse){}

    public void Trigger(DerivedStatusEffect dse, StatusEnum statusEnum){}

    private StatusEnum[] statusEnums = new StatusEnum[] {};
    public StatusEnum[] GetStatusEnums()
    {
        return statusEnums;
    }
}
