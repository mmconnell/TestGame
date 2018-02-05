using UnityEngine;
using System.Collections;
using Enums.Trigger;

public class AuraStatusEffectWrapper : I_StatusEffectWrapper
{
    public CharacterManager Owner { get; private set; }

    public AuraStatusEffectWrapper()
    {

    }

    public void Apply(CharacterManager target)
    {
        throw new System.NotImplementedException();
    }

    public void End(CharacterManager target)
    {
        throw new System.NotImplementedException();
    }

    public void Remove(CharacterManager target)
    {
        throw new System.NotImplementedException();
    }

    public void Trigger(CharacterTrigger trigger, CharacterManager status)
    {
        throw new System.NotImplementedException();
    }
}
