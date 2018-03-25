using Enums.Trigger;

public class DelayedStatusEffectOld : I_BaseStatusEffectOld
{
    public DeliveryPackOld DeliveryPack { get; set; }
    public DelayedStatusEffectOld(DeliveryPackOld deliveryPack)
    {
        DeliveryPack = deliveryPack;
    }

    public void End(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper)
    {
        //target.Apply(DeliveryPack, owner);
    }

    public void Remove(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper){}

    public void Trigger(CharacterTrigger trigger, CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper){}

    public void Apply(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper){}

    void I_BaseStatusEffectOld.Remove(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper){}
}