using Enums.Damage;

public class PercentBasedDamage : DamagePack
{
    public PercentOfDamage TypeOfPercent { get; set; }
    private double percent;
    public double Percent { get { return this.percent/100.0; } set { this.percent = value; } }
    public bool SourceIsOwner { get; set; }
    public PercentBasedDamage(DamageType damageType, PercentOfDamage typeOfPercent, double percent, bool sourceIsOwner) : base(damageType)
    {
        TypeOfPercent = typeOfPercent;
        Percent = percent;
        SourceIsOwner = sourceIsOwner;
    }

    public override int GetAmount(CharacterManager target, CharacterManager owner)
    {
        CharacterManager source = SourceIsOwner ? owner : target;
        double health = 0;
        switch(TypeOfPercent)
        {
            case PercentOfDamage.MAX_HEALTH:
                health = source.MaxHealth;
                break;
            case PercentOfDamage.CURRENT_HEALTH:
                health = source.Health;
                break;
            case PercentOfDamage.MISSING_HEALTH:
                health = source.MaxHealth - source.Health;
                break;
        }
        return CalculateResistance(target, (health * (Percent)));
    }
}

public enum PercentOfDamage
{
    MAX_HEALTH, CURRENT_HEALTH, MISSING_HEALTH
}
