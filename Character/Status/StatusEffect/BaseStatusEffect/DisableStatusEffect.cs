using Enums;
using Enums.CombatAction;
using Enums.Trigger;

public class DisableStatusEffect : BaseStatusEffect
{
    private CombatAction CombatAction { get; set; }

    public DisableStatusEffect(Status owner, CombatAction combatAction, int duration, Persistance persistance) : base(owner, persistance, duration) { }

    public new void Trigger(Trigger effect, Status status)
    {
        base.Trigger(effect, status);
    }

    public new void Apply(Status status)
    {
        status.DisableCount[CombatAction.ActionValue]++;
        base.Apply(status);
    }

    public new void Remove(Status status)
    {
        status.DisableCount[CombatAction.ActionValue]--;
        base.Apply(status);
    }
}