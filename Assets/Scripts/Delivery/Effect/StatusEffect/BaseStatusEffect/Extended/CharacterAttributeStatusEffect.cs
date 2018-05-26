using EnumsNew;

public class CharacterAttributeStatusEffect : I_BaseStatusEffect
{
    private Character_Attribute_Enum CharacterAttribute { get; set; }
    private AttributeShift AttributeShift { get; set; }
    public DerivedStatusEffect DerivedStatusEffect { get; set; }

    public CharacterAttributeStatusEffect(DerivedStatusEffect derivedStatusEffect, Character_Attribute_Enum characterAttribute, double attributeShift, Character_Attribute_Shift_Type shiftType)
    {
        CharacterAttribute = characterAttribute;
        AttributeShift = new AttributeShift();
        DerivedStatusEffect = derivedStatusEffect;
        switch (shiftType)
        {
            case Character_Attribute_Shift_Type.DIVISOR:
                if (attributeShift < 1 || attributeShift > 100)
                {
                    throw new System.Exception("Attribute Shift of " + attributeShift + " is invalid");
                }
                AttributeShift.Devisor += attributeShift;
                break;
            case Character_Attribute_Shift_Type.MULTIPLIER:
                if (attributeShift < 1 || attributeShift > 100)
                {
                    throw new System.Exception("Attribute shift of " + attributeShift + " is invalid");
                }
                AttributeShift.Multiplier += attributeShift;
                break;
            case Character_Attribute_Shift_Type.FLAT:
                AttributeShift.Flat += attributeShift;
                break;
        }
    }

    public void Apply()
    {
        //((CharacterManager)InformationManager.GetManager(DerivedStatusEffect.target)).CharacterAttributeAlteration[CharacterAttribute.CharacterAttributeValue].Add(AttributeShift);
    }

    public void End()
    {
        Remove();
    }

    public void Remove()
    {
        //((CharacterManager)InformationManager.GetManager(DerivedStatusEffect.target)).CharacterAttributeAlteration[CharacterAttribute.CharacterAttributeValue].Remove(AttributeShift);
    }
}
