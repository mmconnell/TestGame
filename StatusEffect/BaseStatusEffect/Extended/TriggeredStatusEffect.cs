using Enums;
using Enums.Trigger;

public class TriggeredStatusEffect : I_BaseStatusEffect
{
    private DerivedStatusEffect DerivedStatusEffect { get; set; }
    public CharacterTrigger CharacterTrigger { get; set; }
    public DeliveryPack DeliveryPack { get; set; }

    public TriggeredStatusEffect(DerivedStatusEffect derivedStatusEffect, CharacterTrigger statusTrigger, DeliveryPack deliveryPack)
    {
        DerivedStatusEffect = derivedStatusEffect;
        CharacterTrigger = statusTrigger;
        DeliveryPack = deliveryPack;
    }

    public void Apply()
    {
        EventManager.StartListening(DerivedStatusEffect.target, CharacterTrigger.ToString(), Trigger);
    }

    public void Remove()
    {
        EventManager.StopListening(DerivedStatusEffect.target, CharacterTrigger.ToString(), Trigger);
    }

    public void End()
    {
        Remove();
    }

    private void Trigger()
    {
        DerivedStatusEffect.target.Apply(DeliveryPack, DerivedStatusEffect.owner);
    }
}