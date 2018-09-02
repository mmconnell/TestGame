using EnumsNew;
using Manager;
using System.Collections.Generic;
using UnityEngine;

namespace DeliverySystem
{
    public class CreatureTypeCondition : Condition
    {
        public List<Character_Type> CharacterTypes {get; set;}

        public CreatureTypeCondition(Conditional conditional, Character_Type characterType) : base(conditional) {
            CharacterTypes = new List<Character_Type>
            {
                characterType
            };
        }

        public void Add(Character_Type character_Type) {
            CharacterTypes.Add(character_Type);
        }

        public void Add(List<Character_Type> characterTypes) {
            CharacterTypes.AddRange(characterTypes);
        }

        public override bool Apply(ToolManager owner, ToolManager target, List<I_Result> results)
        {
            foreach(Character_Type characterType in CharacterTypes) {
                
            }
            return false;
        } 
    }
}