using Enums;
using Enums.Trigger;

public abstract class TriggeredStatusEffect : BaseStatusEffect
{
    public CharacterTrigger CharacterTrigger { get; set; }
    public TriggeredStatusEffect(CharacterManager owner, Persistance persistance, int duration, CharacterTrigger statusTrigger) : base(owner, persistance, duration)
    {
        CharacterTrigger = statusTrigger;
    }

    public new void Apply(CharacterManager characterManager)
    {
        characterManager.StatusEffects[CharacterTrigger.TriggerValue].Add(this);
        base.Apply(characterManager);
    }

    public new void Trigger(CharacterTrigger characterTrigger, CharacterManager characterManager)
    {
        if(characterTrigger.Equals(CharacterTrigger))
        {
            TriggerEffect(characterManager);
        }
        base.Trigger(characterTrigger, characterManager);
    }

    public abstract void TriggerEffect(CharacterManager characterManager);

    public new void End(CharacterManager characterManager)
    {
        characterManager.StatusEffects[CharacterTrigger.TriggerValue].Remove(this);
        base.End(characterManager);
    }
}
