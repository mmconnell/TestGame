using EnumsNew;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class ResistanceTool : MonoBehaviour
    {
        public Dictionary<Damage_Type_Enum, int> baseResistances;
        public Dictionary<Damage_Type_Enum, List<NumberShift>> Shifts { get; private set; }
        public Dictionary<Damage_Type_Enum, int> CurrentResistance { get; private set; }

        public void Awake()
        {
            InformationManager.RegisterComponent(gameObject, typeof(ResistanceTool), this);
            baseResistances = new Dictionary<Damage_Type_Enum, int>();
            Shifts = new Dictionary<Damage_Type_Enum, List<NumberShift>>();
            CurrentResistance = new Dictionary<Damage_Type_Enum, int>();
            foreach(Damage_Type_Enum damageType in Enum.GetValues(typeof(Damage_Type_Enum)))
            {
                baseResistances.Add(damageType, 0);
                CurrentResistance.Add(damageType, 0);
                Shifts.Add(damageType, new List<NumberShift>());
            }
        }

        public void OnDestroy()
        {
            InformationManager.UnRegisterComponent(gameObject, typeof(ResistanceTool));
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
            CurrentResistance.Remove(damageType);
            CurrentResistance.Add(damageType, total);
        }

        public int GetResistance(Damage_Type_Enum damageType)
        {
            return CurrentResistance[damageType];
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
    }
}
