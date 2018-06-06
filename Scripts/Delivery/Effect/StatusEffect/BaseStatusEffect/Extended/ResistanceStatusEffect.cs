using EnumsNew;
using Manager;

public class ResistanceStatusEffect : I_BaseStatusEffect
{
    private Damage_Type_Enum ResistanceType { get; set; }
    private NumberShift NumberShift { get; set; }

    public ResistanceStatusEffect(Damage_Type_Enum resistanceType, int shiftAmount)
    {
        ResistanceType = resistanceType;
        NumberShift = new NumberShift();
        NumberShift.Flat = shiftAmount;
    }

    public void Apply(DerivedStatusEffect dse)
    {
        ResistanceTool resistanceTool = dse.target.Get(ResistanceTool.toolEnum) as ResistanceTool;
        if (resistanceTool)
        {
            resistanceTool.AddShift(ResistanceType, NumberShift);
        }
    }

    public void End(DerivedStatusEffect dse)
    {
        Remove(dse);
    }

    public void Remove(DerivedStatusEffect dse)
    {
        ResistanceTool resistanceTool = dse.target.Get(ResistanceTool.toolEnum) as ResistanceTool;
        if (resistanceTool)
        {
            resistanceTool.RemoveShift(ResistanceType, NumberShift);
        }
    }

    public void Trigger(DerivedStatusEffect dse, StatusEnum statusEnum){}

    public static StatusEnum[] statusEnums = new StatusEnum[] { };
    public StatusEnum[] GetStatusEnums()
    {
        return statusEnums;
    }
}
