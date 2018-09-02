using DeliverySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Manager
{
    public class AuraCreator
    {
        public static AuraStatusEffect CreateAura(ToolManager source, AuraSelector auraSelector)
        {
            return new AuraStatusEffect(source, source, -1, auraSelector);
        }

        public static AuraSelector CreateAuraColliderChecker(float radius, DerivedStatusEffect effect, Material material)
        {
            GameObject gameObject = new GameObject();
            AuraColliderChecker acc = gameObject.AddComponent<AuraColliderChecker>();
            acc.AuraEffect = effect;
            acc.material = material;
            acc.radius = radius;
            return acc;
        }
    }
}
