﻿using UnityEngine;
using System.Collections;
using Enums.Trigger;
using System.Collections.Generic;
using Enums;

public class AuraEffectStatusEffectWrapper : I_StatusEffectWrapper
{
    public CharacterManager Owner { get; private set; }
    public I_BaseStatusEffectOld StatusEffect { get; private set; }

    public AuraEffectStatusEffectWrapper(I_BaseStatusEffectOld statusEffect, CharacterManager owner)
    {
        StatusEffect = statusEffect;
        Owner = owner;
    }

    public void Apply(CharacterManager target)
    {
        StatusEffect.Apply(target, Owner, this);
    }

    public void End(CharacterManager target)
    {
        StatusEffect.End(target, Owner, this);
    }

    public void Remove(CharacterManager target)
    {
        StatusEffect.Remove(target, Owner, this);
    }

    public void Trigger(CharacterTrigger trigger, CharacterManager target)
    {
        StatusEffect.Trigger(trigger, target, Owner, this);
    }

    public CharacterManager getOwner()
    {
        return Owner;
    }
    
    public Persistance GetPersistance()
    {
        return Persistance.COMBAT;
    }
}