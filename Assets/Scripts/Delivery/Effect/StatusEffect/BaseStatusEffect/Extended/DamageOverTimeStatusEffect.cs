using Delivery;
using Manager;
using System.Collections.Generic;

public class DamageOverTimeStatusEffect : I_BaseStatusEffect
{
    public DamagePack Damage { get; set; }

    public DamageOverTimeStatusEffect(DamagePack damagePack)
    {
        Damage = damagePack;
    }

    public void Apply(DerivedStatusEffect dse){}

    public void Remove(DerivedStatusEffect dse){}

    public void End(DerivedStatusEffect dse)
    {
        Remove(dse);
    }

    private void TurnStart(DerivedStatusEffect dse)
    {
        Damage.Apply(dse.owner, dse.target);
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
