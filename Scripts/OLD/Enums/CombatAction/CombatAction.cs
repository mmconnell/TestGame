namespace Enums.CombatAction
{
    public class CombatAction
    {
        private CombatAction Parent { get; set; }
        public Character_Action_Enum ActionValue { get; set; }

        public CombatAction(Character_Action_Enum actionValue)
        {
            ActionValue = actionValue;
        }

        public CombatAction(Character_Action_Enum actionValue, CombatAction parent)
        {
            ActionValue = actionValue;
            Parent = parent;
        }

        public bool Equals(CombatAction action)
        {
            bool returnValue = action.ActionValue.Equals(ActionValue);
            if(Parent != null)
            {
                returnValue = returnValue || Parent.Equals(action);
            }
            return returnValue;
        }
    }
}