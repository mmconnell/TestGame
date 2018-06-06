using EnumsNew;
using Manager;
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

        public int GetAmount(ToolManager owner, ToolManager target)
        {
            return DynamicNumber.GetIntAmount(owner, target);
        }

        public void Apply(ToolManager owner, ToolManager target)
        {
            int total = GetAmount(owner, target);
            List<KeyValuePair<Damage_Type_Enum, float>> damageTypeList = DamageTypes.GetDamageTypes(target);
            DeliveryTool deliveryTool = target.Get(DeliveryTool.toolEnum) as DeliveryTool;
            DeliveryResult deliveryResult = deliveryTool.GetCurrent();
            foreach (KeyValuePair<Damage_Type_Enum, float> pair in damageTypeList)
            {
                Damage_Type_Enum damageType = pair.Key;
                float percent = pair.Value;
                int portion = (int)(total * percent);
                deliveryResult.DamageDone[(int)damageType] += portion;
                if (portion != 0)
                {
                    deliveryResult.empty = false;
                }
            }
        }
    }
}