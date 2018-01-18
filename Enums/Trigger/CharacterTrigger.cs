namespace Enums.Trigger
{
    public class CharacterTrigger
    {
        private CharacterTrigger Parent { get; set; }
        public Character_Trigger_Enum TriggerValue { get; set; }
        public CharacterTrigger(Character_Trigger_Enum triggerValue)
        {
            Parent = null;
            TriggerValue = triggerValue;
        }

        public CharacterTrigger(Character_Trigger_Enum triggerValue, CharacterTrigger parent)
        {
            Parent = parent;
            TriggerValue = triggerValue;
        }

        public bool Equals(CharacterTrigger trigger)
        {
            bool returnValue = trigger.TriggerValue.Equals(TriggerValue);
            if (Parent != null)
            {
                returnValue = returnValue || Parent.Equals(trigger);
            }
            return returnValue;
        }
    }
}
