namespace Enums.CharacterStatus
{
    public class ChatacterStatuses
    {
        public static CharacterStatus STAT = new CharacterStatus(Character_Status_Enum.STAT);
            public static CharacterStatus PHYSICAL_STAT = new CharacterStatus(Character_Status_Enum.PHYSICAL_STAT, STAT);
                public static CharacterStatus STRENGTH = new CharacterStatus(Character_Status_Enum.STRENGTH, PHYSICAL_STAT);
                public static CharacterStatus DEXTERITY = new CharacterStatus(Character_Status_Enum.DEXTERITY, PHYSICAL_STAT);
                public static CharacterStatus CONSTITUTION = new CharacterStatus(Character_Status_Enum.CONSTITUTION, PHYSICAL_STAT);
            public static CharacterStatus MENTAL_STAT = new CharacterStatus(Character_Status_Enum.MENTAL_STAT, STAT);
                public static CharacterStatus INTELLIGENCE = new CharacterStatus(Character_Status_Enum.INTELLIGENCE, MENTAL_STAT);
                public static CharacterStatus WISDOM = new CharacterStatus(Character_Status_Enum.WISDOM, MENTAL_STAT);
                public static CharacterStatus CHARISMA = new CharacterStatus(Character_Status_Enum.CHARISMA, MENTAL_STAT);

        public static CharacterStatus RESISTANCE = new CharacterStatus(Character_Status_Enum.RESISTANCE);
            public static CharacterStatus PHYSICAL_RESISTANCE = new CharacterStatus(Character_Status_Enum.PHYSICAL_RESISTANCE, RESISTANCE);
                public static CharacterStatus PIERCING_RESISTANCE = new CharacterStatus(Character_Status_Enum.PIERCING_RESISTANCE, PHYSICAL_RESISTANCE);
                public static CharacterStatus BLUDGEONING_RESISTANCE = new CharacterStatus(Character_Status_Enum.BLUDGEONING_RESISTANCE, PHYSICAL_RESISTANCE);
                public static CharacterStatus SLASHING_RESISTANCE = new CharacterStatus(Character_Status_Enum.SLASHING_RESISTANCE, PHYSICAL_RESISTANCE);
            public static CharacterStatus MAGICAL_RESISTANCE = new CharacterStatus(Character_Status_Enum.MAGICAL_RESISTANCE, RESISTANCE);
                public static CharacterStatus FIRE_RESISTANCE = new CharacterStatus(Character_Status_Enum.FIRE_RESISTANCE, MAGICAL_RESISTANCE);
                public static CharacterStatus COLD_RESISTANCE = new CharacterStatus(Character_Status_Enum.COLD_RESISTANCE, MAGICAL_RESISTANCE);
                public static CharacterStatus POISON_RESISTANCE = new CharacterStatus(Character_Status_Enum.POISON_RESISTANCE, MAGICAL_RESISTANCE);

        public static CharacterStatus STARTING_AP = new CharacterStatus(Character_Status_Enum.STARTING_AP);
        public static CharacterStatus AP_REGEN = new CharacterStatus(Character_Status_Enum.AP_REGEN);
        public static CharacterStatus MOVEMENT = new CharacterStatus(Character_Status_Enum.MOVEMENT);
        public static CharacterStatus JUMP_HEIGHT = new CharacterStatus(Character_Status_Enum.JUMP_HEIGHT);
        public static CharacterStatus EVADE_CHANCE = new CharacterStatus(Character_Status_Enum.EVADE_CHANCE);
        public static CharacterStatus BLOCK_CHANCE = new CharacterStatus(Character_Status_Enum.BLOCK_CHANCE);
        public static CharacterStatus PHYSICAL_ARMOR = new CharacterStatus(Character_Status_Enum.PHYSICAL_ARMOR);
        public static CharacterStatus MAGICAL_ARMOR = new CharacterStatus(Character_Status_Enum.MAGICAL_ARMOR);
        public static CharacterStatus PHYSICAL_ARMOR_REGEN = new CharacterStatus(Character_Status_Enum.PHYSICAL_ARMOR_REGEN);
        public static CharacterStatus MAGICAL_ARMOR_REGEN = new CharacterStatus(Character_Status_Enum.MAGICAL_ARMOR_REGEN);
    }
}