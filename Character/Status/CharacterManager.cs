using System;
using System.Collections.Generic;
using Enums;
using Enums.CombatAction;
using Enums.Trigger;

public class CharacterManager {
    public int Health { get; set; }

    public Dictionary<Character_Trigger_Enum, List<BaseStatusEffect>> StatusEffects { get; set; }
    public Dictionary<Character_Action_Enum, int> DisableCount { get; set; }
    public Dictionary<Character_Attribute_Enum, int> CharacterAttributeAlteration { get; set; }

    public CharacterManager()
    {
        StatusEffects = new Dictionary<Character_Trigger_Enum, List<BaseStatusEffect>>();
        DisableCount = new Dictionary<Character_Action_Enum, int>();
        CharacterAttributeAlteration = new Dictionary<Character_Attribute_Enum, int>();

        foreach (Character_Action_Enum a in Enum.GetValues(typeof(Character_Action_Enum)))
        {
            DisableCount.Add(a, 0);
        }
        foreach (Character_Trigger_Enum se in Enum.GetValues(typeof(Character_Trigger_Enum)))
        {
            StatusEffects.Add(se, new List<BaseStatusEffect>());
        }
        foreach (Character_Attribute_Enum cae in Enum.GetValues(typeof(Character_Attribute_Enum)))
        {
            CharacterAttributeAlteration.Add(cae, 0);
        }
    }

    public void Trigger(CharacterTrigger trigger)
    {
        foreach(BaseStatusEffect se in StatusEffects[trigger.TriggerValue])
        {
            se.Trigger(trigger, this);
        }
    }

    public void Apply(DeliveryPack deliveryPack)
    {
        foreach (DamagePack dp in deliveryPack.DamagePack)
        {
            Apply(dp);
        }
        foreach (EffectPack ep in deliveryPack.EffectPack)
        {
            Apply(ep);
        }
    }

    public void Apply(DamagePack damagePack)
    {

    }

    public void Apply(EffectPack effectPack)
    {

    }

    public void TakeDamage()
    {

    }
}
