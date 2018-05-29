using Delivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Manager
{
    public class AuraCreator
    {
        public static void CreateAura(GameObject source, GameObject auraSelectorGO, Type effect)
        {
            AuraStatusEffect ase = source.AddComponent<AuraStatusEffect>();
            ase.aura = auraSelectorGO;
            ase.auraEffect = effect;
            ase.owner = source;
            AuraSelector auraSelector = auraSelectorGO.GetComponent<AuraSelector>();
            auraSelector.AuraEffect = effect;
            ase.auraSelector = auraSelector;
        }

        public static GameObject CreateAuraColliderChecker(float radius, Material material)
        {
            GameObject gameObject = new GameObject();
            AuraColliderChecker acc = gameObject.AddComponent<AuraColliderChecker>();
            acc.material = material;
            acc.radius = radius;
            return gameObject;
        }
    }
}
