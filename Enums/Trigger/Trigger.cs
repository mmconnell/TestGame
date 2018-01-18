namespace Enums.Trigger
{
    public class Trigger
    {
        private Trigger Parent { get; set; }
        public Trigger_Enum TriggerValue { get; set; }
        public Trigger(Trigger_Enum triggerValue)
        {
            Parent = null;
            TriggerValue = triggerValue;
        }

        public Trigger(Trigger_Enum triggerValue, Trigger parent)
        {
            Parent = parent;
            TriggerValue = triggerValue;
        }

        public bool Equals(Trigger trigger)
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
