using UnityEngine;
using System.Collections;
using Enums.CombatAction;

public class DisableStatusEffect2 : I_BaseStatusEffect2
{
    private CombatAction CombatAction { get; set; }
    private DerivedStatusEffect2 DerivedStatusEffect { get; set; }

    public DisableStatusEffect2(DerivedStatusEffect2 derivedStatusEffect, CombatAction combatAction)
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
