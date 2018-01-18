public class EffectPack 
{
    public int ChanceToSucceed { get; set; }
    public BaseStatusEffect StatusEffect { get; set; }

    public EffectPack(int chanceToSucceed, BaseStatusEffect statusEffect)
    {
        ChanceToSucceed = chanceToSucceed;
        StatusEffect = statusEffect;
    }
}
