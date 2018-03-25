using Enums;
using System.Collections.Generic;

public abstract class DerivedStatusEffectOld
{
    public List<I_BaseStatusEffectOld> BaseStatusEffects { get; set; }

    public DerivedStatusEffectOld()
    {
        BaseStatusEffects = new List<I_BaseStatusEffectOld>();
    }

    public void AddBaseStatusEffect(I_BaseStatusEffectOld baseStatusEffect)
    {
        BaseStatusEffects.Add(baseStatusEffect);
    }

    public void Apply(CharacterManager target, CharacterManager owner, Persistance persistance, int duration)
    {
        if (target.BuffAndDebuffList.Contains(this))
        {
            return;
        }
        foreach (I_BaseStatusEffectOld bse in BaseStatusEffects)
        {
            I_StatusEffectWrapper statusEffectWrapper = new StatusEffectWrapper(bse, owner, persistance, duration);
            statusEffectWrapper.Apply(target);
        }
    }
}
