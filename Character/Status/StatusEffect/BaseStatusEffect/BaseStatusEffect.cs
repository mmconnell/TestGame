using Enums;
using Enums.Trigger;

public class BaseStatusEffect
{
    public static int NO_DURATION = -1;
    public int Duration { get; set; }
    private Status Owner { get; set; }
    public Persistance Persistance { get; set; }

    public BaseStatusEffect(Status owner, Persistance persistance, int duration)
    {
        Duration = duration;
        Owner = owner;
        Persistance = persistance;
    }

    public void Trigger(Trigger effect, Status status)
    {
        if (effect.Equals(Triggers.TURN_END) && Duration != NO_DURATION)
        {
            Duration--;
            if (Duration <= 0)
            {
                End(status);
            }
        }
    }
    public void Apply(Status status) { }
    public void Remove(Status status) { }
    public void End(Status status) { }

    public object Icon { get; set; }
    public bool IsHidden { get; set; }
}
