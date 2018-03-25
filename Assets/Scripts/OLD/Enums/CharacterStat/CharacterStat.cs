using Enums;
namespace Enums.CharacterStat {
    public class CharacterStat
    {
        public Character_Stat StatValue { get; set; }

        public CharacterStat(Character_Stat characterStat)
        {
            StatValue = characterStat;
        }
    }
}