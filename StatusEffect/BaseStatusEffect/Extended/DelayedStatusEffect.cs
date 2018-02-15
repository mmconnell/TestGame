using UnityEngine;
using System.Collections;

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
        DerivedStatusEffect.target.Apply(DeliveryPack, DerivedStatusEffect.owner);
    }

    public void Remove(){}
}
