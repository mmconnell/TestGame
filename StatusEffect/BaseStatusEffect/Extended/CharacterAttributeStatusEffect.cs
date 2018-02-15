using Enums.CharacterStatus;
using Enums;

public class CharacterAttributeStatusEffect : I_BaseStatusEffect
{
    private CharacterAttribute CharacterAttribute { get; set; }
    private AttributeShift AttributeShift { get; set; }
    public DerivedStatusEffect DerivedStatusEffect { get; set; }

    public CharacterAttributeStatusEffect(DerivedStatusEffect derivedStatusEffect, CharacterAttribute characterAttribute, double attributeShift, Character_Attribute_Shift_Type shiftType)
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
        DerivedStatusEffect.target.CharacterAttributeAlteration[CharacterAttribute.CharacterAttributeValue].Add(AttributeShift);
    }

    public void End()
    {
        Remove();
    }

    public void Remove()
    {
        DerivedStatusEffect.target.CharacterAttributeAlteration[CharacterAttribute.CharacterAttributeValue].Remove(AttributeShift);
    }
}
