using Enums;
using System.Collections.Generic;

public abstract class DerivedStatusEffect
{
    public List<I_BaseStatusEffect> BaseStatusEffects { get; set; }

    public DerivedStatusEffect()
    {
        BaseStatusEffects = new List<I_BaseStatusEffect>();
    }

    public void AddBaseStatusEffect(I_BaseStatusEffect baseStatusEffect)
    {
        BaseStatusEffects.Add(baseStatusEffect);
    }

    public void Apply(CharacterManager target, CharacterManager owner, Persistance persistance, int duration)
    {
        if (target.BuffAndDebuffList.Contains(this))
        {
            return;
        }
        foreach (I_BaseStatusEffect bse in BaseStatusEffects)
        {
            I_StatusEffectWrapper statusEffectWrapper = new StatusEffectWrapper(bse, owner, persistance, duration);
            statusEffectWrapper.Apply(target);
        }
    }
}
