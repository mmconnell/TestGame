using Enums.Damage;
using UnityEngine;

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
        return Amount;
    }

    public override string DamagePackType()
    {
        return "FlatDamage";
    }
}
