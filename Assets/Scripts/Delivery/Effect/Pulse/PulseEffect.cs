using System;
using UnityEngine;
using Utility;

namespace Delivery
{
    public class PulseEffect : I_Effect
    {
        private float initialPulse;
        private float growth;
        private float rate;
        private float max;
        private float width;
        private I_Effect effect;
        private Material material;
        private bool targetOwner;

        public PulseEffect(I_Effect effect, float initialPulse, float growth, float rate, float max, float width, Material material, bool targetOwner)
        {
            this.initialPulse = initialPulse;
            this.growth = growth;
            this.rate = rate;
            this.max = max;
            this.width = width;
            this.effect = effect;
            this.material = material;
            this.targetOwner = targetOwner;
        }

        public void Apply(GameObject owner, GameObject target, DeliveryResult deliveryResult)
        {
            GameObject go = new GameObject();
            
            go.transform.position = target.transform.position;
            go.transform.parent = target.transform;
            PulseCollider pc = go.AddComponent<PulseCollider>();
            pc.radius = initialPulse;
            pc.growth = growth;
            pc.rate = rate;
            pc.max = max;
            pc.width = width;
            pc.effect = effect;
            pc.material = material;
            pc.isNotTargetingOwner = !targetOwner;
            pc.deliveryResult = deliveryResult;
            pc.owner = target;
        }
    }
}
