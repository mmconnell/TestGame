using Enums;
using Enums.CombatAction;
using Enums.Trigger;

public class DisableStatusEffect : BaseStatusEffect
{
    private CombatAction CombatAction { get; set; }

    public DisableStatusEffect(CharacterManager owner, CombatAction combatAction, int duration, Persistance persistance) : base(owner, persistance, duration) { }

    public new void Trigger(CharacterTrigger effect, CharacterManager status)
    {
        base.Trigger(effect, status);
    }

    public new void Apply(CharacterManager status)
    {
        status.DisableCount[CombatAction.ActionValue]++;
        base.Apply(status);
    }

    public new void Remove(CharacterManager status)
    {
        status.DisableCount[CombatAction.ActionValue]--;
        base.Apply(status);
    }
}