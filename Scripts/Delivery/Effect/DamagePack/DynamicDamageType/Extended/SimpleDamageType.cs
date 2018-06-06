using EnumsNew;
using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Delivery
{
    public class SimpleDamageType : I_DynamicDamageType
    {
        List<KeyValuePair<Damage_Type_Enum, float>> damages;

        public SimpleDamageType(Damage_Type_Enum damageType)
        {
            damages = new List<KeyValuePair<Damage_Type_Enum, float>>
            {
                new KeyValuePair<Damage_Type_Enum, float>(damageType, 1f)
            };
        }

        public List<KeyValuePair<Damage_Type_Enum, float>> GetDamageTypes(ToolManager target)
        {
            return damages;
        }
    }
}
