using EnumsNew;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class DamageTool : AbstractTool
    {
        private static Damage_Type_Enum[] damageTypes;

        public static Damage_Type_Enum[] GetDamageTypes()
        {
            if (damageTypes == null)
            {
                Array enums = Enum.GetValues(typeof(Damage_Type_Enum));
                damageTypes = new Damage_Type_Enum[enums.Length];
                foreach (Damage_Type_Enum damageType in enums)
                {
                    damageTypes[(int)damageType] = damageType;
                }
            }
            return damageTypes;
        }

        public static Damage_Type_Enum GetDamageType(int index)
        {
            Damage_Type_Enum[] damageTypes = GetDamageTypes();
            if (index < damageTypes.Length)
            {
                return damageTypes[index];
            }
            return Damage_Type_Enum.BLUDGEONING;
        }

        ResistanceTool resistanceTool;

        public static ToolEnum toolEnum;

        public override void Awake()
        {
            base.Awake();
            toolEnum = ToolEnum;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }

        public void TakeDamage(Damage_Type_Enum damageType, int damage)
        {
            float resistanceMult = 1;
            if (!resistanceTool)
            {
                resistanceTool = toolManager.Get(ResistanceTool.toolEnum) as ResistanceTool;
            }
            if (resistanceTool)
            {
                resistanceMult = resistanceTool.GetResistancePercentage(damageType);
            }
            int finalDamage = (int)Math.Round(damage * resistanceMult, 0);
            if (InformationManager.IsLogging())
            {
                InformationManager.Log(gameObject.name + " took " + finalDamage + " " + damageType.ToString() + " damage and had " + resistanceMult + " resistance");
            }
        }

        public override ToolEnum GetToolEnum()
        {
            return toolEnum;
        }
    }
}
