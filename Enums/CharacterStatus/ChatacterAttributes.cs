namespace Enums.CharacterStatus
{
    public class CharacterAttributes
    {
        public static CharacterAttribute STAT = new CharacterAttribute(Character_Attribute_Enum.STAT);
            public static CharacterAttribute PHYSICAL_STAT = new CharacterAttribute(Character_Attribute_Enum.PHYSICAL_STAT, STAT);
                public static CharacterAttribute STRENGTH = new CharacterAttribute(Character_Attribute_Enum.STRENGTH, PHYSICAL_STAT);
                public static CharacterAttribute DEXTERITY = new CharacterAttribute(Character_Attribute_Enum.DEXTERITY, PHYSICAL_STAT);
                public static CharacterAttribute CONSTITUTION = new CharacterAttribute(Character_Attribute_Enum.CONSTITUTION, PHYSICAL_STAT);
            public static CharacterAttribute MENTAL_STAT = new CharacterAttribute(Character_Attribute_Enum.MENTAL_STAT, STAT);
                public static CharacterAttribute INTELLIGENCE = new CharacterAttribute(Character_Attribute_Enum.INTELLIGENCE, MENTAL_STAT);
                public static CharacterAttribute WISDOM = new CharacterAttribute(Character_Attribute_Enum.WISDOM, MENTAL_STAT);
                public static CharacterAttribute CHARISMA = new CharacterAttribute(Character_Attribute_Enum.CHARISMA, MENTAL_STAT);

        public static CharacterAttribute RESISTANCE = new CharacterAttribute(Character_Attribute_Enum.RESISTANCE);
            public static CharacterAttribute PHYSICAL_RESISTANCE = new CharacterAttribute(Character_Attribute_Enum.PHYSICAL_RESISTANCE, RESISTANCE);
                public static CharacterAttribute PIERCING_RESISTANCE = new CharacterAttribute(Character_Attribute_Enum.PIERCING_RESISTANCE, PHYSICAL_RESISTANCE);
                public static CharacterAttribute BLUDGEONING_RESISTANCE = new CharacterAttribute(Character_Attribute_Enum.BLUDGEONING_RESISTANCE, PHYSICAL_RESISTANCE);
                public static CharacterAttribute SLASHING_RESISTANCE = new CharacterAttribute(Character_Attribute_Enum.SLASHING_RESISTANCE, PHYSICAL_RESISTANCE);
            public static CharacterAttribute MAGICAL_RESISTANCE = new CharacterAttribute(Character_Attribute_Enum.MAGICAL_RESISTANCE, RESISTANCE);
                public static CharacterAttribute FIRE_RESISTANCE = new CharacterAttribute(Character_Attribute_Enum.FIRE_RESISTANCE, MAGICAL_RESISTANCE);
                public static CharacterAttribute COLD_RESISTANCE = new CharacterAttribute(Character_Attribute_Enum.COLD_RESISTANCE, MAGICAL_RESISTANCE);
                public static CharacterAttribute POISON_RESISTANCE = new CharacterAttribute(Character_Attribute_Enum.POISON_RESISTANCE, MAGICAL_RESISTANCE);

        public static CharacterAttribute STARTING_AP = new CharacterAttribute(Character_Attribute_Enum.STARTING_AP);
        public static CharacterAttribute AP_REGEN = new CharacterAttribute(Character_Attribute_Enum.AP_REGEN);
        public static CharacterAttribute MOVEMENT = new CharacterAttribute(Character_Attribute_Enum.MOVEMENT);
        public static CharacterAttribute JUMP_HEIGHT = new CharacterAttribute(Character_Attribute_Enum.JUMP_HEIGHT);
        public static CharacterAttribute EVADE_CHANCE = new CharacterAttribute(Character_Attribute_Enum.EVADE_CHANCE);
        public static CharacterAttribute BLOCK_CHANCE = new CharacterAttribute(Character_Attribute_Enum.BLOCK_CHANCE);
        public static CharacterAttribute PHYSICAL_ARMOR = new CharacterAttribute(Character_Attribute_Enum.PHYSICAL_ARMOR);
        public static CharacterAttribute MAGICAL_ARMOR = new CharacterAttribute(Character_Attribute_Enum.MAGICAL_ARMOR);
        public static CharacterAttribute PHYSICAL_ARMOR_REGEN = new CharacterAttribute(Character_Attribute_Enum.PHYSICAL_ARMOR_REGEN);
        public static CharacterAttribute MAGICAL_ARMOR_REGEN = new CharacterAttribute(Character_Attribute_Enum.MAGICAL_ARMOR_REGEN);
    }
}