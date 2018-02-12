using UnityEngine;
using System.Collections;

public class DelayedStatusEffect2 : I_BaseStatusEffect2
{
    public DeliveryPack DeliveryPack { get; set; }
    public DerivedStatusEffect2 DerivedStatusEffect { get; set; }

    public DelayedStatusEffect2(DerivedStatusEffect2 derivedStatusEffect, DeliveryPack deliveryPack)
    {
        DeliveryPack = deliveryPack;
        DerivedStatusEffect = derivedStatusEffect;
    }

    public void Apply(){}

    public void End()
    {
        DerivedStatusEffect.target.Apply(DeliveryPack, DerivedStatusEffect.owner);
    }

    public void Remove(){}
}
