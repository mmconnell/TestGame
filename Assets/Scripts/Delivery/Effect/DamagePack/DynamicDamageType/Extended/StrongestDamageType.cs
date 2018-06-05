using EnumsNew;
using Manager;
using System.Collections.Generic;
using UnityEngine;

namespace Delivery
{
    public class StrongestDamageType : I_DynamicDamageType
    {
        List<Damage_Type_Enum> damageTypes;

        public StrongestDamageType(List<Damage_Type_Enum> damageTypes)
        {
            this.damageTypes = damageTypes;
        }

        public List<KeyValuePair<Damage_Type_Enum, float>> GetDamageTypes(ToolManager target)
        {
            ResistanceTool resistanceTool = target.Get(ResistanceTool.toolEnum) as ResistanceTool;
            if (!resistanceTool || damageTypes == null || damageTypes.Count == 0)
            {
                return new List<KeyValuePair<Damage_Type_Enum, float>>();
            }
            List<KeyValuePair<Damage_Type_Enum, float>> damages = new List<KeyValuePair<Damage_Type_Enum, float>>();
            int least = 0;
            Damage_Type_Enum leastDamageType = damageTypes[0];
            bool initial = true;
            foreach (Damage_Type_Enum damageType in damageTypes)
            {
                int currentResistance = resistanceTool.GetResistance(damageType);
                if (initial)
                {
                    leastDamageType = damageType;
                    least = currentResistance;
                    initial = false;
                } else if (currentResistance < least)
                {
                    leastDamageType = damageType;
                    least = currentResistance;
                }
            }
            damages.Add(new KeyValuePair<Damage_Type_Enum, float>(leastDamageType, 1f));
            return damages;
        }
    }
}
