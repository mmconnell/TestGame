using EnumsNew;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class ResistanceTool : AbstractTool
    {
        public static ToolEnum toolEnum;

        public int[] baseResistances;
        public List<NumberShift>[] Shifts;
        public int[] CurrentResistance;

        public override void Awake()
        {
            base.Awake();
            toolEnum = ToolEnum;
            int size = Enum.GetValues(typeof(Damage_Type_Enum)).Length;
            baseResistances = new int[size];
            Shifts = new List<NumberShift>[size];
            CurrentResistance = new int[size];
            for (int x = 0; x < size; x++) 
            {
                baseResistances[x] = 0;
                CurrentResistance[x] = 0;
                Shifts[x] = new List<NumberShift>();
            }
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        } 

        public void AddShift(Damage_Type_Enum damageType, NumberShift numberShift)
        {
            Shifts[(int)damageType].Add(numberShift);
            CurrentResistance[(int)damageType] += numberShift.FlatInt();
        }

        public void RemoveShift(Damage_Type_Enum damageType, NumberShift numberShift)
        {
            Shifts[(int)damageType].Remove(numberShift);
            CurrentResistance[(int)damageType] -= numberShift.FlatInt();
        } 

        public void AddFlat(Damage_Type_Enum damageType, int flat)
        {
            baseResistances[(int)damageType] += flat;
            CurrentResistance[(int)damageType] += flat;
        }

        public void Calculate(Damage_Type_Enum damageType)
        {
            int total = baseResistances[(int)damageType];
            foreach (NumberShift numberShift in Shifts[(int)damageType])
            {
                total += numberShift.FlatInt();
            }
            CurrentResistance[(int)damageType] = total;
        }

        public int GetResistance(Damage_Type_Enum damageType)
        {
            return CurrentResistance[(int)damageType];
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
