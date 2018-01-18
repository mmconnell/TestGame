namespace Enums.CombatAction
{
    public class CombatActions
    {
        public static CombatAction TAKE_TURN = new CombatAction(Character_Action_Enum.TAKE_TURN);
        public static CombatAction WAIT = new CombatAction(Character_Action_Enum.WAIT);
        public static CombatAction USE_ITEM = new CombatAction(Character_Action_Enum.USE_ITEM);
        public static CombatAction USE_ABILITY = new CombatAction(Character_Action_Enum.USE_ABILITY);

        public static CombatAction USE_MIND = new CombatAction(Character_Action_Enum.USE_MIND);
            public static CombatAction SPEAK = new CombatAction(Character_Action_Enum.SPEAK, USE_MIND);
        public static CombatAction MOVE = new CombatAction(Character_Action_Enum.MOVE);
            public static CombatAction MOVE_ARMS = new CombatAction(Character_Action_Enum.MOVE_ARMS, MOVE);
                public static CombatAction DEFEND = new CombatAction(Character_Action_Enum.DEFEND, MOVE_ARMS);
                public static CombatAction ATTACK = new CombatAction(Character_Action_Enum.ATTACK, MOVE_ARMS);
            public static CombatAction MOVE_LEGS = new CombatAction(Character_Action_Enum.MOVE_LEGS, MOVE);
                public static CombatAction ESCAPE = new CombatAction(Character_Action_Enum.ESCAPE, MOVE_LEGS);
    }
}