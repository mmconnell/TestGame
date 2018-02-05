namespace Enums.Trigger
{
    public class CharacterTriggers
    {
        public static CharacterTrigger TURN_START = new CharacterTrigger(Character_Trigger_Enum.TURN_START);
        public static CharacterTrigger TURN_END = new CharacterTrigger(Character_Trigger_Enum.TURN_END);
        public static CharacterTrigger DEFEND = new CharacterTrigger(Character_Trigger_Enum.DEFEND);
        public static CharacterTrigger RUN_AWAY = new CharacterTrigger(Character_Trigger_Enum.RUN_AWAY);
        public static CharacterTrigger ATTACK = new CharacterTrigger(Character_Trigger_Enum.ATTACK);
        public static CharacterTrigger ATTACKED = new CharacterTrigger(Character_Trigger_Enum.ATTACKED);
        public static CharacterTrigger USE_ABILITY = new CharacterTrigger(Character_Trigger_Enum.USE_ABILITY);

        public static CharacterTrigger DEAL_DAMAGE = new CharacterTrigger(Character_Trigger_Enum.DEAL_DAMAGE);
            public static CharacterTrigger DEAL_PHYSICAL = new CharacterTrigger(Character_Trigger_Enum.DEAL_PHYSICAL, DEAL_DAMAGE);
                public static CharacterTrigger DEAL_PIERCING = new CharacterTrigger(Character_Trigger_Enum.DEAL_PIERCING, DEAL_PHYSICAL);
                public static CharacterTrigger DEAL_BLUDGEONING = new CharacterTrigger(Character_Trigger_Enum.DEAL_BLUDGEONING, DEAL_PHYSICAL);
                public static CharacterTrigger DEAL_SLASHING = new CharacterTrigger(Character_Trigger_Enum.DEAL_SLASHING, DEAL_PHYSICAL);
            public static CharacterTrigger DEAL_MAGICAL = new CharacterTrigger(Character_Trigger_Enum.DEAL_MAGICAL, DEAL_DAMAGE);
                public static CharacterTrigger DEAL_FIRE = new CharacterTrigger(Character_Trigger_Enum.DEAL_FIRE, DEAL_MAGICAL);
                public static CharacterTrigger DEAL_SHOCK = new CharacterTrigger(Character_Trigger_Enum.DEAL_SHOCK, DEAL_MAGICAL);
                public static CharacterTrigger DEAL_COLD = new CharacterTrigger(Character_Trigger_Enum.DEAL_FIRE, DEAL_MAGICAL);
                public static CharacterTrigger DEAL_POISON = new CharacterTrigger(Character_Trigger_Enum.DEAL_POISION, DEAL_MAGICAL);
            public static CharacterTrigger DEAL_UNTYPED = new CharacterTrigger(Character_Trigger_Enum.DEAL_UNTYPED, DEAL_DAMAGE);

        public static CharacterTrigger RECEIVE_DAMAGE = new CharacterTrigger(Character_Trigger_Enum.RECEIVE_DAMAGE);
            public static CharacterTrigger RECEIVE_PHYSICAL = new CharacterTrigger(Character_Trigger_Enum.RECEIVE_PHYSICAL, RECEIVE_DAMAGE);
                public static CharacterTrigger RECEIVE_PIERCING = new CharacterTrigger(Character_Trigger_Enum.RECEIVE_PIERCING, RECEIVE_PHYSICAL);
                public static CharacterTrigger RECEIVE_BLUDGEONING = new CharacterTrigger(Character_Trigger_Enum.RECEIVE_BLUDGEONING, RECEIVE_PHYSICAL);
                public static CharacterTrigger RECEIVE_SLASHING = new CharacterTrigger(Character_Trigger_Enum.RECEIVE_SLASHING, RECEIVE_PHYSICAL);
            public static CharacterTrigger RECEIVE_MAGICAL = new CharacterTrigger(Character_Trigger_Enum.RECEIVE_MAGICAL, RECEIVE_DAMAGE);
                public static CharacterTrigger RECEIVE_FIRE = new CharacterTrigger(Character_Trigger_Enum.RECEIVE_FIRE, RECEIVE_MAGICAL);
                public static CharacterTrigger RECEIVE_SHOCK = new CharacterTrigger(Character_Trigger_Enum.RECEIVE_SHOCK, RECEIVE_MAGICAL);
                public static CharacterTrigger RECEIVE_COLD = new CharacterTrigger(Character_Trigger_Enum.RECEIVE_FIRE, RECEIVE_MAGICAL);
                public static CharacterTrigger RECEIVE_POISON = new CharacterTrigger(Character_Trigger_Enum.RECEIVE_POISON, RECEIVE_MAGICAL);
            public static CharacterTrigger RECEIVE_UNTYPED = new CharacterTrigger(Character_Trigger_Enum.RECEIVE_UNTYPED, RECEIVE_DAMAGE);

        public static CharacterTrigger HEAL = new CharacterTrigger(Character_Trigger_Enum.HEAL);
        public static CharacterTrigger HEALED = new CharacterTrigger(Character_Trigger_Enum.HEALED);
        public static CharacterTrigger FRAME = new CharacterTrigger(Character_Trigger_Enum.FRAME);
    }
}