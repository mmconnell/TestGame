namespace Enums.CharacterStatus
{
    public class CharacterAttribute
    {
        private CharacterAttribute Parent { get; set; }
        public Character_Attribute_Enum CharacterAttributeValue { get; set; }
        public CharacterAttribute(Character_Attribute_Enum characterStatusValue)
        {
            Parent = null;
            CharacterAttributeValue = characterStatusValue;
        }

        public CharacterAttribute(Character_Attribute_Enum characterStatusValue, CharacterAttribute parent)
        {
            Parent = parent;
            CharacterAttributeValue = characterStatusValue;
        }

        public bool Equals(CharacterAttribute characterStatus)
        {
            bool returnValue = characterStatus.CharacterAttributeValue.Equals(CharacterAttributeValue);
            if (Parent != null)
            {
                returnValue = returnValue || Parent.Equals(characterStatus);
            }
            return returnValue;
        }
    }
}
