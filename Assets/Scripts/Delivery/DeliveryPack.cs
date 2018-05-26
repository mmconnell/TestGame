using System.Collections.Generic;
using UnityEngine;

namespace Delivery
{
    public class DeliveryPack
    {
        public SortedDictionary<int, List<I_Effect>> EffectMap { get; private set; }
        public I_AreaEffect AreaEffect { get; set; }

        public DeliveryPack(SortedDictionary<int, List<I_Effect>> effectMap)
        {
            EffectMap = effectMap ?? new SortedDictionary<int, List<I_Effect>>();
        }

        public DeliveryPack()
        {
            EffectMap = new SortedDictionary<int, List<I_Effect>>();
        }

        public void AddEffect(I_Effect effectPack, int priority)
        {
            if(effectPack != null)
            {
                List<I_Effect> effectPackList = EffectMap[priority];
                if (effectPackList == null)
                {
                    effectPackList = new List<I_Effect>();
                    EffectMap.Add(priority, effectPackList);
                }
                effectPackList.Add(effectPack);
            }
        }

        public DeliveryPack CopyDeliveryPack()
        {
            DeliveryPack newDeliveryPack = new DeliveryPack();
            foreach(KeyValuePair<int, List<I_Effect>> pair in EffectMap)
            {
                List<I_Effect> effectPackList = new List<I_Effect>();
                effectPackList.AddRange(pair.Value);
                newDeliveryPack.EffectMap.Add(pair.Key, effectPackList);
            }
            return newDeliveryPack;
        }

        public void Apply(GameObject owner, I_Position position, DeliveryResult deliveryResult)
        {
            List<GameObject> targets = AreaEffect.GatherTargets(position);
            foreach (KeyValuePair<int, List<I_Effect>> pair in EffectMap)
            {
                foreach (I_Effect effectPack in pair.Value)
                {
                    foreach (GameObject target in targets)
                    {
                        effectPack.Apply(owner, target, deliveryResult);
                    }
                }
            }
        }
    }
}