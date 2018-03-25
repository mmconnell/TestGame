using Enums.Damage;

public class PercentBasedDamageOld : DamagePackOld
{
    public PercentOfDamageOld TypeOfPercent { get; set; }
    private double percent;
    public double Percent { get { return this.percent/100.0; } set { this.percent = value; } }
    public bool SourceIsOwner { get; set; }
    public PercentBasedDamageOld(DamageType damageType, PercentOfDamageOld typeOfPercent, double percent, bool sourceIsOwner) : base(damageType)
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
            case PercentOfDamageOld.MAX_HEALTH:
                health = source.MaxHealth;
                break;
            case PercentOfDamageOld.CURRENT_HEALTH:
                health = source.Health;
                break;
            case PercentOfDamageOld.MISSING_HEALTH:
                health = source.MaxHealth - source.Health;
                break;
        }
        return (int)(health * (Percent));
    }

    public override string DamagePackType()
    {
        return "PercentBasedDamage";
    }
}

public enum PercentOfDamageOld
{
    MAX_HEALTH, CURRENT_HEALTH, MISSING_HEALTH
}
