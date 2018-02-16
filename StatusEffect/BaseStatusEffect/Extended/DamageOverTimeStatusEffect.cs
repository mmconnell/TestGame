﻿using Enums;
using Enums.Trigger;

public class DamageOverTimeStatusEffect : I_BaseStatusEffect
{
    public DamagePack DamagePack { get; set; }
    public DerivedStatusEffect DerivedStatusEffect { get; set; }

    public DamageOverTimeStatusEffect(DerivedStatusEffect derivedStatusEffect, DamagePack damagePack) : base()
    {
        DamagePack = damagePack;
        DerivedStatusEffect = derivedStatusEffect;
    }

    public void Apply()
    {
        EventManager.StartListening(DerivedStatusEffect.target.gameObject, "TURN_START", TurnStart);
    }

    public void Remove()
    {
        EventManager.StopListening(DerivedStatusEffect.target.gameObject, "TURN_START", TurnStart);
    }

    public void End()
    {
        Remove();
    }

    public void TurnStart()
    {
        CharacterManager characterManager = DerivedStatusEffect.target;
        if(characterManager != null)
        {
            characterManager.Apply(DamagePack, DerivedStatusEffect.owner);
        }
    }
}
