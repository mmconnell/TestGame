using Enums.Damage;

public abstract class DamagePack
{
    public DamageType DamageType { get; set; }

    public DamagePack(DamageType damageType)
    {
        DamageType = damageType;
    }

    public abstract int GetAmount(CharacterManager target, CharacterManager owner);

    public void Respond(CharacterManager target, CharacterManager owner, int amount)
    {
        owner.Response(target, amount, DamageType);
    }

    protected int CalculateResistance(CharacterManager target, double amount)
    {
        double resistance = target.GetResistance(DamageType.DamageValue);
        resistance /= 100.0;
        resistance = 1.0 + resistance;
        amount *= resistance;
        return (int)amount;
    }
}
