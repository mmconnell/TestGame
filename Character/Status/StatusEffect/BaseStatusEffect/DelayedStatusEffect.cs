using UnityEngine;
using System.Collections;
using Enums;

public class DelayedStatusEffect : BaseStatusEffect
{
    public DeliveryPack DeliveryPack { get; set; }
    public DelayedStatusEffect(CharacterManager owner, DeliveryPack deliveryPack, Persistance persistance, int duration) : base(owner, persistance, duration)
    {
        foreach(EffectPack ep in deliveryPack.EffectPack)
        {
            if(ep.StatusEffect is DelayedStatusEffect)
            {
                throw new System.Exception("Cannot create a DelayedStatusEffect with a DelayedStatusEffect");
            }
        }
        DeliveryPack = deliveryPack;
    }

    public new void Apply(CharacterManager status)
    {
        status.Apply(DeliveryPack);
        base.Apply(status);
    }
}