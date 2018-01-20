using Enums;
using Enums.Trigger;

public class BaseStatusEffect
{
    public static int NO_DURATION = -1;
    public int Duration { get; set; }
    private CharacterManager Owner { get; set; }
    public Persistance Persistance { get; set; }

    public BaseStatusEffect(CharacterManager owner, Persistance persistance, int duration)
    {
        Duration = duration;
        Owner = owner;
        Persistance = persistance;
    }

    public void Trigger(CharacterTrigger effect, CharacterManager status)
    {
        if (effect.TriggerValue.Equals(CharacterTriggers.TURN_END))
        {
            Duration--;
            if (Duration <= 0)
            {
                End(status);
            }
        }
    }
    public void Apply(CharacterManager characterManager)
    {
        if (Duration != NO_DURATION)
        {
            characterManager.StatusEffects[Character_Trigger_Enum.TURN_END].Add(this);
        }
        characterManager.PersistanceTracker[Persistance].Add(this);
    }

    public void Remove(CharacterManager characterManager)
    {
        End(characterManager);
    }

    public void End(CharacterManager characterManager)
    {
        if (Duration != NO_DURATION)
        {
            characterManager.StatusEffects[Character_Trigger_Enum.TURN_END].Remove(this);
        }
        characterManager.PersistanceTracker[Persistance].Add(this);
    }

    public object Icon { get; set; }
    public bool IsHidden { get; set; }
}
