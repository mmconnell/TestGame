using Enums;
using Enums.Trigger;

public class TriggeredStatusEffect : BaseStatusEffect
{
    public Trigger StatusTrigger { get; set; }
    public TriggeredStatusEffect(Status owner, Trigger statusTrigger, Persistance persistance, int duration) : base(owner, persistance, duration)
    {
        StatusTrigger = statusTrigger;
    }
}
