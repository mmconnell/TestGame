using Manager;
using System.Collections.Generic;
using UnityEngine;

namespace Delivery
{
    public class DeliveryPack
    {
        public SortedDictionary<int, List<I_Effect>> EffectMap { get; set; }
        public I_AreaEffect AreaEffect { get; set; }
        public bool ignoreOwner { get; set; }

        public DeliveryPack(SortedDictionary<int, List<I_Effect>> effectMap, I_AreaEffect areaEffect)
        {
            EffectMap = effectMap ?? new SortedDictionary<int, List<I_Effect>>();
            AreaEffect = areaEffect;
        }

        public DeliveryPack()
        {
            EffectMap = new SortedDictionary<int, List<I_Effect>>();
            AreaEffect = new SingleTarget();
        }

        public void AddEffect(I_Effect effectPack, int priority)
        {
            if(effectPack != null)
            {
                List<I_Effect> effectPackList;
                if (!EffectMap.ContainsKey(priority))
                {
                    effectPackList = new List<I_Effect>();
                    EffectMap.Add(priority, effectPackList);
                }
                else
                {
                    effectPackList = EffectMap[priority];
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

        public void Apply(ToolManager owner, I_Position position)
        {
            List<ToolManager> targets = AreaEffect.GatherTargets(position, owner);
            foreach (KeyValuePair<int, List<I_Effect>> pair in EffectMap)
            {
                foreach (I_Effect effectPack in pair.Value)
                {
                    foreach (ToolManager target in targets)
                    {
                        effectPack.Apply(owner, target, ignoreOwner);
                    }
                }
            }
        }
    }
}