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
        if (effect.Equals(CharacterTriggers.TURN_END) && Duration != NO_DURATION)
        {
            Duration--;
            if (Duration <= 0)
            {
                End(status);
            }
        }
    }
    public void Apply(CharacterManager status) { }
    public void Remove(CharacterManager status) { }
    public void End(CharacterManager status) { }

    public object Icon { get; set; }
    public bool IsHidden { get; set; }
}
