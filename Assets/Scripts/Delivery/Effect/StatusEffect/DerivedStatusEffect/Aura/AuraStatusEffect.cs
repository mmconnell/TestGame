using UnityEngine;
using System;

namespace Delivery
{
    public class AuraStatusEffect : DerivedStatusEffect
    {
        public Type auraEffect;
        public AuraSelector auraSelector;
        public GameObject aura;

        public override void Start()
        {
            if (auraEffect == null || !auraEffect.IsSubclassOf(typeof(DerivedStatusEffect)))
            {
                Debug.LogError("AuraEffect in AuraStatusEffect2 Must be a subclass type of 'DerivedStatusEffect2'");
            }
            aura.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 1);
            aura.transform.parent = gameObject.transform;
            aura.name = auraEffect.Name + " Aura";
            auraSelector.AuraEffect = auraEffect;
            auraSelector.parent = this;
            base.Start();
            auraSelector.Initiate();
        }

        public override void OnDisable()
        {
            foreach (I_BaseStatusEffect bse in BaseStatusEffects)
            {
                bse.End();
            }
        }

        public override string GetName()
        {
            return base.GetName() + auraEffect.Name;
        }
    }
}