using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnumsNew;
using UnityEngine;

namespace Delivery
{
    public class SharedRatio : I_DynamicDamageType
    {
        private List<KeyValuePair<Damage_Type_Enum, float>> damageRatios;

        public SharedRatio(List<KeyValuePair<Damage_Type_Enum, float>> damageRatios)
        {
            if (damageRatios == null)
            {
                this.damageRatios = new List<KeyValuePair<Damage_Type_Enum, float>>();
            }
            else
            {
                this.damageRatios = damageRatios;
            }
        }

        public List<KeyValuePair<Damage_Type_Enum, float>> GetDamageTypes(GameObject target)
        {
            return damageRatios;
        }
    }
}
