using Enums.Damage;

public class DamagePack
{
    public double DamageValue { get; set; }
    public DamageType Damage { get; set; }
    public bool CanMiss { get; set; }
    public double HitChance { get; set; }

    public DamagePack(double damageValue, DamageType damage)
    {
        DamageValue = damageValue;
        Damage = damage;
        CanMiss = false;
        HitChance = 0;
    }

    public DamagePack(double damageValue, DamageType damage, double hitChance)
    {
        DamageValue = damageValue;
        Damage = damage;
        CanMiss = true;
        HitChance = hitChance;
    }
}
