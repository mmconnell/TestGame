﻿using Enums.CombatAction;

public abstract class DisableStatusEffect : I_BaseStatusEffect
{
    private CombatAction CombatAction { get; set; }
    private DerivedStatusEffect DerivedStatusEffect { get; set; }

    public DisableStatusEffect()
    {
        DerivedStatusEffect = derivedStatusEffect;
        CombatAction = combatAction;
    }

    public void Apply()
    {
        ApplyEffect();
    }

    public void End()
    {
        Remove();
    }

    public void Remove()
    {
        RemoveEffect();
    }

    public abstract void ApplyEffect();
    public abstract void RemoveEffect();
}
