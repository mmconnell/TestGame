using Enums;

public class EffectPack 
{
    public int ChanceToSucceed { get; set; }
    public DerivedStatusEffect StatusEffect { get; set; }
    public I_BaseStatusEffect BaseStatusEffect { get; set; }
    public Persistance Persistance { get; set; }
    public int Duration { get; set; }

    public EffectPack(int chanceToSucceed, DerivedStatusEffect statusEffect, Persistance persistance, int duration)
    {
        ChanceToSucceed = chanceToSucceed;
        StatusEffect = statusEffect;
        Persistance = persistance;
        Duration = duration;
    }

    public EffectPack(int chanceToSucceed, I_BaseStatusEffect statusEffect, Persistance persistance, int duration)
    {
        ChanceToSucceed = chanceToSucceed;
        BaseStatusEffect = statusEffect;
        Persistance = persistance;
        Duration = duration;
    }
}
