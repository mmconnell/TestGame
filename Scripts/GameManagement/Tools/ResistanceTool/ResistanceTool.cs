using EnumsNew;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class ResistanceTool : AbstractTool
    {
        public static ToolEnum toolEnum;

        public ResistancePack[] resistances;

        public override void Awake()
        {
            base.Awake();
            toolEnum = ToolEnum;
            int size = Enum.GetValues(typeof(Damage_Type_Enum)).Length;
            resistances = new ResistancePack[size];
            for (int x = 0; x < size; x++) 
            {
                resistances[x] = new ResistancePack();
            }
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        } 

        public void AddShift(Damage_Type_Enum damageType, NumberShift numberShift)
        {
            resistances[(int)damageType].AddShift(numberShift);
        }

        public void RemoveShift(Damage_Type_Enum damageType, NumberShift numberShift)
        {
            resistances[(int)damageType].AddShift(numberShift);
        } 

        public void AddBase(Damage_Type_Enum damageType, int flat)
        {
            resistances[(int)damageType].AddBase(flat);
        }

        public void Calculate(Damage_Type_Enum damageType)
        {
            resistances[(int)damageType].Calculate();
        }

        public int GetResistance(Damage_Type_Enum damageType)
        {
            return resistances[(int)damageType].CurrentValue;
        }

        public float GetResistancePercentage(Damage_Type_Enum damageType)
        {
            float resistance = GetResistance(damageType);
            float resistancePercentage = 0f;
            if (resistance >= 0)
            {
                resistancePercentage = (100f - resistance)/100f;
            }
            else
            {
                resistancePercentage = (100f - resistance)/100f;
            }
            return resistancePercentage;
        }

        public override ToolEnum GetToolEnum()
        {
            return toolEnum;
        }
    }
}
