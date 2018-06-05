using EnumsNew;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class ResistanceTool : AbstractTool
    {
        public static ToolEnum toolEnum;

        public Dictionary<Damage_Type_Enum, int> baseResistances;
        public Dictionary<Damage_Type_Enum, List<NumberShift>> Shifts { get; private set; }
        public List<int> CurrentResistance { get; private set; }

        public override void Awake()
        {
            base.Awake();
            toolEnum = ToolEnum;
            baseResistances = new Dictionary<Damage_Type_Enum, int>();
            Shifts = new Dictionary<Damage_Type_Enum, List<NumberShift>>();
            CurrentResistance = new List<int>();
            foreach(Damage_Type_Enum damageType in Enum.GetValues(typeof(Damage_Type_Enum)))
            {
                baseResistances.Add(damageType, 0);
                CurrentResistance.Add(0);
                Shifts.Add(damageType, new List<NumberShift>());
            }
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        } 

        public void AddShift(Damage_Type_Enum damageType, NumberShift numberShift)
        {
            Shifts[damageType].Add(numberShift);
            Calculate(damageType);
        }

        public void RemoveShift(Damage_Type_Enum damageType, NumberShift numberShift)
        {
            Shifts[damageType].Remove(numberShift);
            Calculate(damageType);
        } 

        public void AddFlat(Damage_Type_Enum damageType, int flat)
        {
            baseResistances[damageType] += flat;
            Calculate(damageType);
        }

        public void Calculate(Damage_Type_Enum damageType)
        {
            int total = baseResistances[damageType];
            foreach (NumberShift numberShift in Shifts[damageType])
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
