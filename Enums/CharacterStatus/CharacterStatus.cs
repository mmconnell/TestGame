namespace Enums.CharacterStatus
{
    public class CharacterStatus
    {
        private CharacterStatus Parent { get; set; }
        public Character_Status_Enum CharacterStatusValue { get; set; }
        public CharacterStatus(Character_Status_Enum characterStatusValue)
        {
            Parent = null;
            CharacterStatusValue = characterStatusValue;
        }

        public CharacterStatus(Character_Status_Enum characterStatusValue, CharacterStatus parent)
        {
            Parent = parent;
            CharacterStatusValue = characterStatusValue;
        }

        public bool Equals(CharacterStatus characterStatus)
        {
            bool returnValue = characterStatus.CharacterStatusValue.Equals(CharacterStatusValue);
            if (Parent != null)
            {
                returnValue = returnValue || Parent.Equals(characterStatus);
            }
            return returnValue;
        }
    }
}
