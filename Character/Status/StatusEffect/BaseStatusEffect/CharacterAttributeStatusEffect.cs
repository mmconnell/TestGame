using Enums;
using Enums.CharacterStatus;

public class CharacterAttributeStatusEffect : BaseStatusEffect
{
    public CharacterAttribute CharacterAttribute { get; set; }
    private int AttributeShift { get; set; }

    public CharacterAttributeStatusEffect(CharacterManager owner, Persistance persistance, int duration, CharacterAttribute characterAttribute, int attributeShift) : base(owner, persistance, duration)
    {
        CharacterAttribute = characterAttribute;
        AttributeShift = attributeShift;
    }
}
