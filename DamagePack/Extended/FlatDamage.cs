using Enums.Damage;

public class FlatDamage : DamagePack
{
    private int Amount { get; set; }

    public FlatDamage(DamageType damageType, int amount) : base(damageType)
    {
        Amount = amount;
    }

    public int GetAmount()
    {
        return Amount;
    }

    public override int GetAmount(CharacterManager target, CharacterManager owner)
    {
        return CalculateResistance(target, Amount);
    }
}
