using UnityEngine;
using System.Collections;
using Enums.CombatAction;

public class DisableStatusEffect : I_BaseStatusEffect
{
    private CombatAction CombatAction { get; set; }
    private DerivedStatusEffect DerivedStatusEffect { get; set; }

    public DisableStatusEffect(DerivedStatusEffect derivedStatusEffect, CombatAction combatAction)
    {
        DerivedStatusEffect = derivedStatusEffect;
        CombatAction = combatAction;
    }

    public void Apply()
    {
        DerivedStatusEffect.target.DisableCount[CombatAction.ActionValue]++;
    }

    public void End()
    {
        Remove();
    }

    public void Remove()
    {
        DerivedStatusEffect.target.DisableCount[CombatAction.ActionValue]--;
    }
}
