using EnumsNew;
using System.Collections.Generic;
using UnityEngine;

namespace Delivery
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

        public override bool Apply(GameObject owner, GameObject target, DeliveryPack pack, DeliveryPack newPack, List<Result> results, Dictionary<Delivery_Pack_Shifts, AttributeShift> shifts) {
            foreach(Character_Type characterType in CharacterTypes) {
                //LOGIC
            }
            return false;
        } 
    }
}