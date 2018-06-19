using EnumsNew;
using Manager;

public abstract class DisableStatusEffect : I_BaseStatusEffect
{
    private Character_Action_Enum CombatAction { get; set; }

    public DisableStatusEffect()
    {
        //DerivedStatusEffect = derivedStatusEffect;
        //CombatAction = combatAction;
    }

    public void Apply(DerivedStatusEffect dse)
    {
        ApplyEffect(dse);
    }

    public void End(DerivedStatusEffect dse)
    {
        Remove(dse);
    }

    public void Remove(DerivedStatusEffect dse)
    {
        RemoveEffect(dse);
    }

    public abstract void ApplyEffect(DerivedStatusEffect dse);
    public abstract void RemoveEffect(DerivedStatusEffect dse);

    public void Trigger(DerivedStatusEffect dse, StatusEnum statusEnum) {}

    public static StatusEnum[] statusEnums = new StatusEnum[] {};
    public StatusEnum[] GetStatusEnums()
    {
        return statusEnums;
    }
}
