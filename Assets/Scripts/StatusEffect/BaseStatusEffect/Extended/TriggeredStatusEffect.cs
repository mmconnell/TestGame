using Delivery;
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
        EventManager.StartListening(DerivedStatusEffect.target.gameObject, CharacterTrigger.ToString(), Trigger);
    }

    public void Remove()
    {
        EventManager.StopListening(DerivedStatusEffect.target.gameObject, CharacterTrigger.ToString(), Trigger);
    }

    public void End()
    {
        Remove();
    }

    private void Trigger()
    {
        ((CharacterManager)InformationManager.GetManager(DerivedStatusEffect.target)).Apply(DeliveryPack, ((CharacterManager)InformationManager.GetManager(DerivedStatusEffect.owner)));
    }
}