using System;
using System.Collections.Generic;
using Enums;
using Enums.CombatAction;
using Enums.Trigger;

public class Status {
    public int Health { get; set; }

    public Dictionary<Trigger_Enum, List<BaseStatusEffect>> StatusEffects { get; set; }
    public Dictionary<Action_Enum, int> DisableCount { get; set; }

    public Status()
    {
        StatusEffects = new Dictionary<Trigger_Enum, List<BaseStatusEffect>>();
        DisableCount = new Dictionary<Action_Enum, int>();

        foreach (Action_Enum a in Enum.GetValues(typeof(Action_Enum)))
        {
            DisableCount.Add(a, 0);
        }
        foreach (Trigger_Enum se in Enum.GetValues(typeof(Trigger_Enum)))
        {
            StatusEffects.Add(se, new List<BaseStatusEffect>());
        }
    }

    public void Trigger(Trigger trigger)
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
