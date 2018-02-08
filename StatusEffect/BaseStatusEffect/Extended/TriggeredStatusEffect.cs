using Enums;
using Enums.Trigger;

public class TriggeredStatusEffect : I_BaseStatusEffect
{
    public CharacterTrigger CharacterTrigger { get; set; }
    public DeliveryPack DeliveryPack { get; set; }

    public TriggeredStatusEffect(CharacterTrigger statusTrigger, DeliveryPack deliveryPack)
    {
        CharacterTrigger = statusTrigger;
        DeliveryPack = deliveryPack;
    }

    public void Apply(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper)
    {
        target.StatusEffects[CharacterTrigger.TriggerValue].Add(wrapper);
    }

    public void Trigger(CharacterTrigger characterTrigger, CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper)
    {
        if(characterTrigger.Equals(CharacterTrigger))
        {
            target.Apply(DeliveryPack, owner);
        }
    }

    public void End(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper)
    {
        target.StatusEffects[CharacterTrigger.TriggerValue].Remove(wrapper);
    }

    public void Remove(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper)
    {
        End(target, owner, wrapper);
    }
}