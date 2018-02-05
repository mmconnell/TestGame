public class EffectPack 
{
    public int ChanceToSucceed { get; set; }
    public StatusEffectWrapper StatusEffect { get; set; }

    public EffectPack(int chanceToSucceed, StatusEffectWrapper statusEffect)
    {
        ChanceToSucceed = chanceToSucceed;
        StatusEffect = statusEffect;
    }
}
