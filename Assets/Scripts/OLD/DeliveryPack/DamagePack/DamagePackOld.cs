using Enums.Damage;

public abstract class DamagePackOld
{
    public DamageType DamageType { get; set; }

    public DamagePackOld(DamageType damageType)
    {
        DamageType = damageType;
    }

    public abstract int GetAmount(CharacterManager target, CharacterManager owner);

    public virtual void Apply(CharacterManager target, CharacterManager owner)
    {
       // target.TakeDamage(GetAmount(target, owner), DamageType, owner);
    }

    public abstract string DamagePackType();

    public virtual void Respond(CharacterManager target, CharacterManager owner, int amount)
    {
       // owner.Response(target, amount, DamageType);
    }

    public virtual bool Contains(string type)
    {
        return type.Equals(DamagePackType());
    }
}
