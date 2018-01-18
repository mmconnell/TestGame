using Enums.Damage;

public class DamagePack
{
    public double DamageValue { get; set; }
    public Damage Damage { get; set; }
    public bool CanMiss { get; set; }
    public double HitChance { get; set; }

    public DamagePack(double damageValue, Damage damage)
    {
        DamageValue = damageValue;
        Damage = damage;
        CanMiss = false;
        HitChance = 0;
    }

    public DamagePack(double damageValue, Damage damage, double hitChance)
    {
        DamageValue = damageValue;
        Damage = damage;
        CanMiss = true;
        HitChance = hitChance;
    }
}
