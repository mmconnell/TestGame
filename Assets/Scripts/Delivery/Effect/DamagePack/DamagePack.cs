using EnumsNew;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Delivery
{
    public class DamagePack : I_Effect
    {
        public I_DynamicDamageType DamageTypes{ get; set; }
        public DynamicNumber DynamicNumber { get; set; }

        public DamagePack(I_DynamicDamageType damageTypes, DynamicNumber dynamicNumber)
        {
            DamageTypes = damageTypes;
            DynamicNumber = dynamicNumber;
        }

        public int GetAmount(GameObject owner, GameObject target)
        {
            return DynamicNumber.GetIntAmount(owner, target);
        }

        public void Apply(GameObject owner, GameObject target, DeliveryResult deliveryResult)
        {
            int total = GetAmount(owner, target);
            List<KeyValuePair<Damage_Type_Enum, float>> damageTypeList = DamageTypes.GetDamageTypes(target);
            foreach (KeyValuePair<Damage_Type_Enum, float> pair in damageTypeList)
            {
                Damage_Type_Enum damageType = pair.Key;
                float percent = pair.Value;
                int portion = (int)(total * percent);
                if (deliveryResult.Get(target).DamageDone.ContainsKey(damageType))
                {
                    deliveryResult.Get(target).DamageDone[damageType] += portion;
                }
                else
                {
                    deliveryResult.Get(target).DamageDone.Add(damageType, portion);
                }
            }
        }
    }
}