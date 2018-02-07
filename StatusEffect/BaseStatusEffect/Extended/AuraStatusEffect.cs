using Enums;
using Enums.Trigger;
using System.Collections.Generic;
using UnityEngine;

public class AuraStatusEffect : I_BaseStatusEffect
{
    public EffectPack StatusEffect { get; set; }
    public double Meters { get; set; }
    public TeamTarget TeamToTarget { get; set; }

    public AuraStatusEffect(EffectPack statusEffect, TeamTarget teamTarget ,double meters)
    {
        StatusEffect = statusEffect;
        Meters = meters;
        TeamToTarget = teamTarget;
    }

    public void Trigger(CharacterTrigger trigger, CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper)
    {
        if(trigger == CharacterTriggers.FRAME)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(target.Parent.transform.position, (float)target.GetRadius(Meters));
            HashSet<CharacterManager> charactersInRadius = new HashSet<CharacterManager>();
            HashSet<CharacterManager> last = target.AuraLastEffected.ContainsKey(wrapper) ? target.AuraLastEffected[wrapper] : new HashSet<CharacterManager>();
            List<CharacterManager> needToAddTo = new List<CharacterManager>();
            foreach(Collider2D col in colliders)
            { 
                GameObject go = col.gameObject;
                PoorGuy pg = go.GetComponent<PoorGuy>();
                
                if (pg != null)
                {
                    CharacterManager cm = pg.CharacterManager;
                    charactersInRadius.Add(cm);
                    if(!last.Remove(cm))
                    {
                        needToAddTo.Add(cm);
                    }
                } 
            }
            foreach(CharacterManager cm in last)
            {
                ClearCharacterAura(cm, wrapper);
            }
            owner.AuraLastEffected[wrapper] = charactersInRadius;
            foreach(CharacterManager cm in needToAddTo)
            {
                List<I_StatusEffectWrapper> wrappers = new List<I_StatusEffectWrapper>();
                if (StatusEffect.StatusEffect == null)
                {
                    I_StatusEffectWrapper sew = new AuraEffectStatusEffectWrapper(StatusEffect.BaseStatusEffect, owner, TeamToTarget);
                    sew.Apply(cm);
                    wrappers.Add(sew);
                }
                else
                {
                    foreach (I_BaseStatusEffect bse in StatusEffect.StatusEffect.BaseStatusEffects)
                    {
                        I_StatusEffectWrapper sew = new AuraEffectStatusEffectWrapper(bse, wrapper.getOwner(), TeamToTarget);
                        sew.Apply(cm);
                        wrappers.Add(sew);
                    }
                }
                cm.Auras[wrapper] = wrappers;
            }
        }
    }

    public void Apply(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper)
    {
        target.StatusEffects[CharacterTriggers.FRAME.TriggerValue].Add(wrapper);
    }

    public void Remove(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper)
    {
        target.StatusEffects[CharacterTriggers.FRAME.TriggerValue].Remove(wrapper);
        HashSet<CharacterManager> last = target.AuraLastEffected.ContainsKey(wrapper) ? target.AuraLastEffected[wrapper] : new HashSet<CharacterManager>();
        foreach (CharacterManager cm in last)
        {
            ClearCharacterAura(cm, wrapper);
        }
    }

    public void End(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper)
    {
        target.StatusEffects[CharacterTriggers.FRAME.TriggerValue].Remove(wrapper);
        HashSet<CharacterManager> last = target.AuraLastEffected.ContainsKey(wrapper) ? target.AuraLastEffected[wrapper] : new HashSet<CharacterManager>();
        foreach (CharacterManager cm in last)
        {
            List<I_StatusEffectWrapper> auras = cm.Auras[wrapper];
            foreach (I_StatusEffectWrapper sew in auras)
            {
                sew.End(cm);
            }
            cm.Auras.Remove(wrapper);
        }
    }

    private void ClearCharacterAura(CharacterManager cm, I_StatusEffectWrapper wrapper)
    {
        List<I_StatusEffectWrapper> auras = cm.Auras[wrapper];
        foreach (I_StatusEffectWrapper sew in auras)
        {
            sew.Remove(cm);
        }
        cm.Auras.Remove(wrapper);
    }
}
