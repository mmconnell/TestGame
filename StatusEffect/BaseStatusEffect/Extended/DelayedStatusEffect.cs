using Enums.Trigger;
using System.Collections.Generic;

public class DelayedStatusEffect : I_BaseStatusEffect
{
    public DeliveryPack DeliveryPack { get; set; }
    public DelayedStatusEffect(DeliveryPack deliveryPack)
    {
        DeliveryPack = deliveryPack;
    }

    public void End(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper)
    {
        target.Apply(DeliveryPack, owner);
    }

    public void Remove(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper){}

    public void Trigger(CharacterTrigger trigger, CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper){}

    public void Apply(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper){}

    void I_BaseStatusEffect.Remove(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper){}
}