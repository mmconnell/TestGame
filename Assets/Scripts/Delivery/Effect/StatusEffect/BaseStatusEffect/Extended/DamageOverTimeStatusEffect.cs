using Delivery;
using Manager;

public class DamageOverTimeStatusEffect : I_BaseStatusEffect
{
    public DamagePack DamagePack { get; set; }

    public DamageOverTimeStatusEffect(DamagePack damagePack)
    {
        DamagePack = damagePack;
    }

    public void Apply(DerivedStatusEffect dse){}

    public void Remove(DerivedStatusEffect dse){}

    public void End(DerivedStatusEffect dse)
    {
        Remove(dse);
    }

    private void TurnStart(DerivedStatusEffect dse)
    {
        DamagePack.Apply(dse.owner, dse.target, false);
    }

    public void Trigger(DerivedStatusEffect dse, StatusEnum statusEnum)
    {
        if (statusEnum.value.Equals(StatusTool.TURN_START_STRING))
        {
            TurnStart(dse);
        }
    }

    private static StatusEnum[] statusEnums = new StatusEnum[] { StatusTool.TURN_START };
    public StatusEnum[] GetStatusEnums()
    {
        return statusEnums;
    }
}
