using Enums;
using Enums.CombatAction;
using Enums.Trigger;

public class DisableStatusEffectOld : I_BaseStatusEffectOld
{
    private CombatAction CombatAction { get; set; }

    public DisableStatusEffectOld(CombatAction combatAction)
    {
        CombatAction = combatAction;
    }

    public void Trigger(CharacterTrigger effect, CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper){}

    public void Apply(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper)
    {
        //target.DisableCount[CombatAction.ActionValue]++;
    }

    public void End(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper)
    {
        //target.DisableCount[CombatAction.ActionValue]--;
    }

    public void Remove(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper)
    {
        End(target, owner, wrapper);
    }
}