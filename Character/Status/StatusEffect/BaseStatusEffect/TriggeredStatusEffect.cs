using Enums;
using Enums.Trigger;

public class TriggeredStatusEffect : BaseStatusEffect
{
    public CharacterTrigger StatusTrigger { get; set; }
    public TriggeredStatusEffect(CharacterManager owner, Persistance persistance, int duration, CharacterTrigger statusTrigger) : base(owner, persistance, duration)
    {
        StatusTrigger = statusTrigger;
    }
}
