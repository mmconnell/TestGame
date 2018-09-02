using Manager;
using System.Collections.Generic;

namespace DeliverySystem
{
    public class PriorityDeliveryPack : I_DeliveryPack
    {
        public Dictionary<int, List<I_Effect>> EffectMap
        {
            get
            {
                return effectMap;
            }
            set
            {
                effectMap = value;
                SortEffects();
            }
        }
        public I_AreaEffect AreaEffect { get; set; }

        private List<I_Effect> effectOrder;
        private Dictionary<int, List<I_Effect>> effectMap;

        public PriorityDeliveryPack(Dictionary<int, List<I_Effect>> effectMap, I_AreaEffect areaEffect)
        {
            EffectMap = effectMap ?? new Dictionary<int, List<I_Effect>>();
            AreaEffect = areaEffect ?? DeliveryUtility.SINGLE_TARGET_EFFECT;
            effectOrder = new List<I_Effect>();
            SortEffects();
        }

        public PriorityDeliveryPack()
        {
            EffectMap = new Dictionary<int, List<I_Effect>>();
            AreaEffect = DeliveryUtility.SINGLE_TARGET_EFFECT;
            effectOrder = new List<I_Effect>();
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
            SortEffects();
        }

        private void SortEffects()
        {
            if (effectOrder == null)
            {
                effectOrder = new List<I_Effect>();
            }
            List<KeyValuePair<int, List<I_Effect>>> keyPairList = new List<KeyValuePair<int, List<I_Effect>>>();
            foreach (KeyValuePair<int, List<I_Effect>> pair in EffectMap)
            {
                for (int x = 0; x < keyPairList.Count; x++)
                {
                    if (pair.Key < keyPairList[x].Key)
                    {
                        keyPairList.Insert(x, pair);
                        break;
                    }
                    if (x == keyPairList.Count - 1)
                    {
                        keyPairList.Add(pair);
                        break;
                    }
                }
                if (keyPairList.Count == 0)
                {
                    keyPairList.Add(pair);
                }
            }
            effectOrder.Clear();
            foreach (KeyValuePair<int, List<I_Effect>> pair in keyPairList)
            {
                effectOrder.AddRange(pair.Value);
            }
        }

        public void Apply(ToolManager owner, I_Position position, DeliveryInformation di, bool isNewAttack)
        {
            List<ToolManager> targets = AreaEffect.GatherTargets(position, owner);
            bool canTargetOwner = di.canTargetOwner;
            foreach (ToolManager target in targets)
            {
                if (canTargetOwner || owner != target)
                {
                    DeliveryResultPack drp = null;
                    if (!di.packInfo.TryGetValue(target, out drp))
                    {
                        drp = DeliveryResultPack.GetPack(target);
                        di.packInfo.Add(target, drp);
                    }
                    if (isNewAttack)
                    {
                        if (!drp.GetCurrent().empty)
                        {
                            drp.SetNext();
                        }
                        drp.GetCurrent().empty = false;
                        drp.GetCurrent().Owner = owner;
                    }
                    foreach (I_Effect effect in effectOrder)
                    {
                        di.currentPosition = position;
                        effect.Apply(owner, target, di, drp);
                    }
                }
            }
            if (isNewAttack)
            {
                foreach (DeliveryResultPack drp in di.packInfo.Values)
                {
                    drp.PublishCurrent();
                }
            }
        }
    }
}