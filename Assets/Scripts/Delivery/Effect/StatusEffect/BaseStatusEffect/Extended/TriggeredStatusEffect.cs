using Delivery;
using EnumsNew;
using Manager;

public class TriggeredStatusEffect : I_BaseStatusEffect
{
    public Character_Trigger_Enum CharacterTrigger { get; set; }
    public DeliveryPack DeliveryPack { get; set; }

    public TriggeredStatusEffect(Character_Trigger_Enum statusTrigger, DeliveryPack deliveryPack)
    {
        CharacterTrigger = statusTrigger;
        DeliveryPack = deliveryPack;
    }

    public void Apply(DerivedStatusEffect dse)
    {
        //EventManager.StartListening(dse.target.gameObject, CharacterTrigger.ToString(), Trigger);
    }

    public void Remove(DerivedStatusEffect dse)
    {
        //EventManager.StopListening(dse.target.gameObject, CharacterTrigger.ToString(), Trigger);
    }

    public void End(DerivedStatusEffect dse)
    {
        Remove(dse);
    }

    public void Trigger(DerivedStatusEffect dse, StatusEnum statusEnum)
    {
        DeliveryManager.Run(dse.owner, new ObjectPosition(dse.target), DeliveryPack);
    }

    public static StatusEnum[] statusEnums = new StatusEnum[] {  };
    public StatusEnum[] GetStatusEnums()
    {
        return statusEnums;
    }
}