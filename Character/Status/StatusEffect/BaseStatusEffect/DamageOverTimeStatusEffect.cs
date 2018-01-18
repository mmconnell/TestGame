using Enums;
using Enums.Damage;

public class DamageOverTimeStatusEffect : BaseStatusEffect
{
    public DamagePack DamagePack { get; set; }
    public DamageOverTimeStatusEffect(Status owner, DamagePack damagePack, Persistance persistance, int duration) : base(owner, persistance, duration)
    {
        DamagePack = damagePack;
    }
}
