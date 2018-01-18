namespace Enums.Trigger
{
    public class Triggers
    {
        public static Trigger TURN_START = new Trigger(Trigger_Enum.TURN_START);
        public static Trigger TURN_END = new Trigger(Trigger_Enum.TURN_END);
        public static Trigger DEFEND = new Trigger(Trigger_Enum.DEFEND);
        public static Trigger RUN_AWAY = new Trigger(Trigger_Enum.RUN_AWAY);
        public static Trigger ATTACK = new Trigger(Trigger_Enum.ATTACK);
        public static Trigger ATTACKED = new Trigger(Trigger_Enum.ATTACKED);
        public static Trigger USE_ABILITY = new Trigger(Trigger_Enum.USE_ABILITY);

        public static Trigger DEAL_DAMAGE = new Trigger(Trigger_Enum.DEAL_DAMAGE);
            public static Trigger DEAL_PHYSICAL = new Trigger(Trigger_Enum.DEAL_PHYSICAL, DEAL_DAMAGE);
                public static Trigger DEAL_PIERCING = new Trigger(Trigger_Enum.DEAL_PIERCING, DEAL_PHYSICAL);
                public static Trigger DEAL_BLUDGEONING = new Trigger(Trigger_Enum.DEAL_BLUDGEONING, DEAL_PHYSICAL);
                public static Trigger DEAL_SLASHING = new Trigger(Trigger_Enum.DEAL_SLASHING, DEAL_PHYSICAL);
            public static Trigger DEAL_MAGICAL = new Trigger(Trigger_Enum.DEAL_MAGICAL, DEAL_DAMAGE);
                public static Trigger DEAL_FIRE = new Trigger(Trigger_Enum.DEAL_FIRE, DEAL_MAGICAL);
                public static Trigger DEAL_SHOCK = new Trigger(Trigger_Enum.DEAL_SHOCK, DEAL_MAGICAL);
                public static Trigger DEAL_COLD = new Trigger(Trigger_Enum.DEAL_FIRE, DEAL_MAGICAL);
            public static Trigger DEAL_UNTYPED = new Trigger(Trigger_Enum.DEAL_UNTYPED, DEAL_DAMAGE);

        public static Trigger RECEIVE_DAMAGE = new Trigger(Trigger_Enum.RECEIVE_DAMAGE);
            public static Trigger RECEIVE_PHYSICAL = new Trigger(Trigger_Enum.RECEIVE_PHYSICAL, RECEIVE_DAMAGE);
                public static Trigger RECEIVE_PIERCING = new Trigger(Trigger_Enum.RECEIVE_PIERCING, RECEIVE_PHYSICAL);
                public static Trigger RECEIVE_BLUDGEONING = new Trigger(Trigger_Enum.RECEIVE_BLUDGEONING, RECEIVE_PHYSICAL);
                public static Trigger RECEIVE_SLASHING = new Trigger(Trigger_Enum.RECEIVE_SLASHING, RECEIVE_PHYSICAL);
            public static Trigger RECEIVE_MAGICAL = new Trigger(Trigger_Enum.RECEIVE_MAGICAL, RECEIVE_DAMAGE);
                public static Trigger RECEIVE_FIRE = new Trigger(Trigger_Enum.RECEIVE_FIRE, RECEIVE_MAGICAL);
                public static Trigger RECEIVE_SHOCK = new Trigger(Trigger_Enum.RECEIVE_SHOCK, RECEIVE_MAGICAL);
                public static Trigger RECEIVE_COLD = new Trigger(Trigger_Enum.RECEIVE_FIRE, RECEIVE_MAGICAL);
            public static Trigger RECEIVE_UNTYPED = new Trigger(Trigger_Enum.RECEIVE_UNTYPED, RECEIVE_DAMAGE);
    }
}