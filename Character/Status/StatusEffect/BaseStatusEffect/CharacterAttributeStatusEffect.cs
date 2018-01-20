using Enums;
using Enums.CharacterStatus;

public class CharacterAttributeStatusEffect : BaseStatusEffect
{
    public CharacterAttribute CharacterAttribute { get; set; }
    public AttributeShift AttributeShift { get; set; }

    public CharacterAttributeStatusEffect(CharacterManager owner, Persistance persistance, int duration, CharacterAttribute characterAttribute, int attributeShift, Character_Attribute_Shift_Type shiftType) : base(owner, persistance, duration)
    {
        CharacterAttribute = characterAttribute;
        AttributeShift = new AttributeShift();
        switch(shiftType)
        {
            case Character_Attribute_Shift_Type.DIVISOR:
                if(attributeShift < 1 || attributeShift > 10)
                {
                    throw new System.Exception("Attribute Shift of " + attributeShift + " is invalid");
                }
                AttributeShift.Devisor *= attributeShift;
                break;
            case Character_Attribute_Shift_Type.MULTIPLIER:
                if(attributeShift < 1 || attributeShift > 10)
                {
                    throw new System.Exception("Attribute shift of " + attributeShift + " is invalid");
                }
                AttributeShift.Multiplier *= attributeShift;
                break;
            case Character_Attribute_Shift_Type.FLAT:
                AttributeShift.Flat += attributeShift;
                break;
        }
    }

    public new void Apply(CharacterManager characterManager)
    {
        characterManager.CharacterAttributeAlteration[CharacterAttribute.CharacterAttributeValue].Compose(AttributeShift);
        base.Apply(characterManager);
    }

    public new void End(CharacterManager characterManager)
    {
        characterManager.CharacterAttributeAlteration[CharacterAttribute.CharacterAttributeValue].Decompose(AttributeShift);
        base.End(characterManager);
    }
}
