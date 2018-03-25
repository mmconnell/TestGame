﻿using Enums;

public class EffectPackOld
{
    public int ChanceToSucceed { get; set; }
    public DerivedStatusEffectOld StatusEffect { get; set; }
    public I_BaseStatusEffectOld BaseStatusEffect { get; set; }
    public Persistance Persistance { get; set; }
    public int Duration { get; set; }

    public EffectPackOld(int chanceToSucceed, DerivedStatusEffectOld statusEffect, Persistance persistance, int duration)
    {
        ChanceToSucceed = chanceToSucceed;
        StatusEffect = statusEffect;
        Persistance = persistance;
        Duration = duration;
    }

    public EffectPackOld(int chanceToSucceed, I_BaseStatusEffectOld statusEffect, Persistance persistance, int duration)
    {
        ChanceToSucceed = chanceToSucceed;
        BaseStatusEffect = statusEffect;
        Persistance = persistance;
        Duration = duration;
    }
}