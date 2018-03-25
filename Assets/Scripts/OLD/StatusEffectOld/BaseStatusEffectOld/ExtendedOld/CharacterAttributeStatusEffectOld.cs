using Enums;
using Enums.CharacterStatus;
using Enums.Trigger;

public class CharacterAttributeStatusEffectOld : I_BaseStatusEffectOld
{
    public CharacterAttribute CharacterAttribute { get; set; }
    public AttributeShift AttributeShift { get; set; }

    public CharacterAttributeStatusEffectOld(CharacterAttribute characterAttribute, double attributeShift, Character_Attribute_Shift_Type shiftType)
    {
        CharacterAttribute = characterAttribute;
        AttributeShift = new AttributeShift();
        switch(shiftType)
        {
            case Character_Attribute_Shift_Type.DIVISOR:
                if(attributeShift < 1 || attributeShift > 100)
                {
                    throw new System.Exception("Attribute Shift of " + attributeShift + " is invalid");
                }
                AttributeShift.Devisor += attributeShift;
                break;
            case Character_Attribute_Shift_Type.MULTIPLIER:
                if(attributeShift < 1 || attributeShift > 100)
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

    public void Apply(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper)
    {
      //  target.CharacterAttributeAlteration[CharacterAttribute.CharacterAttributeValue].Add(AttributeShift);
    }

    public void End(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper)
    {
        //target.CharacterAttributeAlteration[CharacterAttribute.CharacterAttributeValue].Remove(AttributeShift);
    }

    public void Trigger(CharacterTrigger trigger, CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper){}

    public void Remove(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper)
    {
        End(target, owner, wrapper);
    }
}
