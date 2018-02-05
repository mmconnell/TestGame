using Enums;
using Enums.Trigger;

public class StatusEffectWrapper : I_StatusEffectWrapper
{
    public static int NO_DURATION = -1;
    public I_BaseStatusEffect StatusEffect { get; private set; }
    public CharacterManager Owner { get; private set; }
    public Persistance Persistance { get; private set; }
    public int Duration { get; private set; }

    public StatusEffectWrapper(I_BaseStatusEffect bse, CharacterManager owner, Persistance persistance, int duration)
    {
        StatusEffect = bse;
        Owner = owner;
        Persistance = persistance;
        Duration = duration;
    }

    public void Trigger(CharacterTrigger trigger, CharacterManager status)
    {
        StatusEffect.Trigger(trigger, status, Owner, this);
        if (trigger.TriggerValue.Equals(CharacterTriggers.TURN_END))
        {
            Duration--;
            if (Duration <= 0)
            {
                End(status);
            }
        }
    }
    public void Apply(CharacterManager target)
    {
        StatusEffect.Apply(target, Owner, this);
        if (Duration != NO_DURATION)
        {
            target.StatusEffects[Character_Trigger_Enum.TURN_END].Add(this);
        }
        target.PersistanceTracker[Persistance].Add(this);
    }

    public void Remove(CharacterManager target)
    {
        StatusEffect.Remove(target, Owner, this);
        if (Duration != NO_DURATION)
        {
            target.StatusEffects[Character_Trigger_Enum.TURN_END].Remove(this);
        }
        target.PersistanceTracker[Persistance].Remove(this);
    }

    public void End(CharacterManager target)
    {
        StatusEffect.End(target, Owner, this);
        if (Duration != NO_DURATION)
        {
            target.StatusEffects[Character_Trigger_Enum.TURN_END].Remove(this);
        }
        target.PersistanceTracker[Persistance].Remove(this);
    }
}