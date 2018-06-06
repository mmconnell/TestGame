using Manager;
using System.Collections.Generic;
using UnityEngine;

namespace Delivery
{
    public class DeliveryPack
    {
        public SortedDictionary<int, List<I_Effect>> EffectMap { get; set; }
        public I_AreaEffect AreaEffect { get; set; }

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

        public void Apply(ToolManager owner, I_Position position, bool isNewAttack)
        {
            List<ToolManager> targets = AreaEffect.GatherTargets(position, owner);
            DeliveryTool ownerDT = owner.Get(DeliveryTool.toolEnum) as DeliveryTool;
            foreach (ToolManager target in targets)
            {
                DeliveryTool dt = target.Get(DeliveryTool.toolEnum) as DeliveryTool;
                if (dt)
                {
                    if (isNewAttack)
                    {
                        if (!dt.GetCurrent().empty)
                        {
                            dt.SetNext();
                        }
                        dt.GetCurrent().empty = false;
                    }
                    foreach (KeyValuePair<int, List<I_Effect>> pair in EffectMap)
                    {
                        foreach (I_Effect effectPack in pair.Value)
                        {
                            effectPack.Apply(owner, target);
                        }
                    }
                    ownerDT.ToDeliver.Add(dt);
                }
            }
            if (isNewAttack)
            {
                foreach (DeliveryTool dt in ownerDT.ToDeliver)
                {
                    dt.PublishCurrent();
                }
            }
        }

        public static void Deliver(DeliveryPack deliveryPack, ToolManager owner, I_Position position)
        {
            deliveryPack.Apply(owner, position, true);
            DeliveryTool ownerDT = owner.Get(DeliveryTool.toolEnum) as DeliveryTool;
            foreach (DeliveryTool dt in ownerDT.ToDeliver)
            {
                dt.Deliver();
            }
            ownerDT.ToDeliver.Clear();
        }
    }
}