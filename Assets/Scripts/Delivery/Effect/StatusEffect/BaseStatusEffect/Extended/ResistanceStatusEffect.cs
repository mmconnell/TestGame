using EnumsNew;
using Manager;

public class ResistanceStatusEffect : I_BaseStatusEffect
{
    private Damage_Type_Enum ResistanceType { get; set; }
    private NumberShift NumberShift { get; set; }
    public DerivedStatusEffect DerivedStatusEffect { get; set; }

    public ResistanceStatusEffect(DerivedStatusEffect derivedStatusEffect, Damage_Type_Enum resistanceType, int shiftAmount)
    {
        ResistanceType = resistanceType;
        NumberShift = new NumberShift();
        NumberShift.Flat = shiftAmount;
        DerivedStatusEffect = derivedStatusEffect;
    }

    public void Apply()
    {
        ResistanceTool resistanceTool = InformationManager.GetRegisteredComponent(DerivedStatusEffect.target, typeof(ResistanceTool)) as ResistanceTool;
        if (resistanceTool)
        {
            resistanceTool.AddShift(ResistanceType, NumberShift);
        }
    }

    public void End()
    {
        Remove();
    }

    public void Remove()
    {
        ResistanceTool resistanceTool = InformationManager.GetRegisteredComponent(DerivedStatusEffect.target, typeof(ResistanceTool)) as ResistanceTool;
        if (resistanceTool)
        {
            resistanceTool.RemoveShift(ResistanceType, NumberShift);
        }
    }
}
