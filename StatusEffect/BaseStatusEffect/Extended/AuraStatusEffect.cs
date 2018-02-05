using Enums.Trigger;
using System.Collections.Generic;
using UnityEngine;

public class AuraStatusEffect : I_BaseStatusEffect
{
    public DerivedStatusEffect StatusEffect { get; set; }
    public double Meters { get; set; }

    public AuraStatusEffect(DerivedStatusEffect statusEffect, double meters)
    {
        StatusEffect = statusEffect;
        Meters = meters;
    }

    public void Trigger(CharacterTrigger trigger, CharacterManager target, CharacterManager owner, StatusEffectWrapper wrapper)
    {
        if(trigger == CharacterTriggers.FRAME)
        {
            Collider[] colliders = Physics.OverlapSphere(target.transform.position, (float)target.GetRadius(Meters));
            HashSet<CharacterManager> charactersInRadius = new HashSet<CharacterManager>();
            HashSet<CharacterManager> last = target.AuraLastEffected[wrapper];
            foreach(Collider col in colliders)
            {
                GameObject go = col.gameObject;
                CharacterManager cm = go.GetComponent<CharacterManager>();
                if(cm != null)
                {
                    charactersInRadius.Add(cm);
                    last.Remove(cm);
                }
            }
            foreach(CharacterManager cm in last) {
                StatusEffect.Remove(cm);
            }
        }
    }

    public void Apply(CharacterManager target, CharacterManager owner, StatusEffectWrapper wrapper)
    {
        target.StatusEffects[CharacterTriggers.FRAME.TriggerValue].Add(wrapper);
    }

    public void Remove(CharacterManager target, CharacterManager owner, StatusEffectWrapper wrapper)
    {
        End(target, owner, wrapper);
    }

    public void End(CharacterManager target, CharacterManager owner, StatusEffectWrapper wrapper)
    {
        target.StatusEffects[CharacterTriggers.FRAME.TriggerValue].Remove(wrapper);
    }
}
