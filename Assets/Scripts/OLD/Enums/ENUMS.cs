namespace Enums
{
    public enum Character_Trigger_Enum
    {
        TURN_START, TURN_END, DEFEND, RUN_AWAY, ATTACK, USE_ABILITY, ATTACKED, FRAME,

        DEAL_DAMAGE,
            DEAL_PHYSICAL,
                DEAL_PIERCING,
                DEAL_BLUDGEONING,
                DEAL_SLASHING,
            DEAL_MAGICAL,
                DEAL_FIRE,
                DEAL_SHOCK,
                DEAL_COLD,
                DEAL_POISION,
            DEAL_UNTYPED,
        RECEIVE_DAMAGE,
            RECEIVE_PHYSICAL,
                RECEIVE_PIERCING,
                RECEIVE_BLUDGEONING,
                RECEIVE_SLASHING,
            RECEIVE_MAGICAL,
                RECEIVE_FIRE,
                RECEIVE_SHOCK,
                RECEIVE_COLD,
                RECEIVE_POISON,
            RECEIVE_UNTYPED,
        HEAL,
        HEALED
    }

    public enum Character_Action_Enum
    {
        TAKE_TURN, WAIT, USE_ITEM, USE_ABILITY,
        USE_MIND,
            SPEAK,
        MOVE,
            MOVE_ARMS,
                DEFEND,
                ATTACK,
        MOVE_LEGS,
                ESCAPE
    }

    public enum Damage_Type_Enum
    {
        PHYSICAL,
            PIERCING,
            BLUDGEONING,
            SLASHING,
        MAGICAL,
            FIRE,
            SHOCK,
            COLD,
            POISON,
        UNTYPED,
        HEALING
    }

    public enum Persistance
    {
        COMBAT, DUNGEON, WORLD
    }

    public enum Character_Stat
    {
        STRENGTH,
        DEXTERITY,
        CONSTITUTION,
        INTELLIGENCE,
        WISDOM,
        CHARISMA
    }

    public enum Character_Attribute_Enum
    {
        STAT,
            PHYSICAL_STAT,
                STRENGTH,
                DEXTERITY,
                CONSTITUTION,
            MENTAL_STAT,
                INTELLIGENCE,
                WISDOM,
                CHARISMA,
        RESISTANCE,
            PHYSICAL_RESISTANCE,
                PIERCING_RESISTANCE,
                BLUDGEONING_RESISTANCE,
                SLASHING_RESISTANCE,
            MAGICAL_RESISTANCE,
                FIRE_RESISTANCE,
                SHOCK_RESISTANCE,
                COLD_RESISTANCE,
                POISON_RESISTANCE,
            HEALING_RESISTANCE,
        STARTING_AP, AP_REGEN, MOVEMENT, JUMP_HEIGHT, EVADE_CHANCE, BLOCK_CHANCE,
        PHYSICAL_ARMOR, MAGICAL_ARMOR, PHYSICAL_ARMOR_REGEN, MAGICAL_ARMOR_REGEN,
        AURA_RADIUS
    }

    public enum Character_Attribute_Shift_Type
    {
        FLAT, MULTIPLIER, DIVISOR
    }

    public enum Team_Target
    {
        ALLIES, ENEMIES, ALL, ALLIES_NOT_SELF, ALL_NOT_SELF
    }
}