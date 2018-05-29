using EnumsNew;
using System;
using UnityEngine;

namespace Manager
{
    public class Damageable : MonoBehaviour
    {
        public void Awake()
        {
            InformationManager.RegisterComponent(gameObject, typeof(Damageable), this);
        }

        public void OnDestroy()
        {
            InformationManager.UnRegisterComponent(gameObject, typeof(Damageable));
        }

        public void TakeDamage(Damage_Type_Enum damageType, int damage)
        {
            ResistanceTool resistanceTool = InformationManager.GetRegisteredComponent(gameObject, typeof(ResistanceTool)) as ResistanceTool;
            float resistanceMult = 1;
            if (resistanceTool)
            {
                resistanceMult = resistanceTool.GetResistancePercentage(damageType);
            }
            int finalDamage = (int)Math.Round(damage * resistanceMult, 0);
            InformationManager.Log(gameObject.name + " took " + finalDamage + " " + damageType.ToString() + " damage and had " + resistanceMult + " resistance");
        }
    }
}
