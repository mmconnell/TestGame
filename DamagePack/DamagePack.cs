using Enums.Damage;

public abstract class DamagePack
{
    public DamageType DamageType { get; set; }

    public DamagePack(DamageType damageType)
    {
        DamageType = damageType;
    }

    public abstract int GetAmount(CharacterManager target, CharacterManager owner);

    public void Apply(CharacterManager target, CharacterManager owner)
    {
        target.TakeDamage(GetAmount(target, owner), DamageType, owner);
    }

    public abstract string DamagePackType();

    public void Respond(CharacterManager target, CharacterManager owner, int amount)
    {
        owner.Response(target, amount, DamageType);
    }

    public bool Contains(string type)
    {
        return type.Equals(DamagePackType());
    }
}
