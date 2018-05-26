using Delivery;
using EnumsNew;

public class TriggeredStatusEffect : I_BaseStatusEffect
{
    private DerivedStatusEffect DerivedStatusEffect { get; set; }
    public Character_Trigger_Enum CharacterTrigger { get; set; }
    public DeliveryPack DeliveryPack { get; set; }

    public TriggeredStatusEffect(DerivedStatusEffect derivedStatusEffect, Character_Trigger_Enum statusTrigger, DeliveryPack deliveryPack)
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
        //((CharacterManager)InformationManager.GetManager(DerivedStatusEffect.target)).Apply(DeliveryPack, ((CharacterManager)InformationManager.GetManager(DerivedStatusEffect.owner)));
    }
}