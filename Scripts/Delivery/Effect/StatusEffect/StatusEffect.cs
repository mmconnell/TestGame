using EnumsNew;
using Manager;
using UnityEngine;

namespace Delivery
{
    public class StatusEffect : I_Effect
    {
        public DerivedStatusEffect Copy { get; set; }
        public Persistance Persistance { get; set; }
        public int Duration { get; set; }

        public StatusEffect(DerivedStatusEffect copy, Persistance persistance, int duration)
        {
            Copy = copy;
            Persistance = persistance;
            Duration = duration;
        }

        public StatusEffect(DerivedStatusEffect copy, Persistance persistance)
        {
            Copy = copy;
            Persistance = persistance;
            Duration = -1;
        }

        public void Apply(ToolManager owner, ToolManager target)
        {
            DeliveryTool deliveryTool = target.Get(DeliveryTool.toolEnum) as DeliveryTool;
            DerivedStatusEffect statusEffect = Copy.Clone(owner, target, Duration);
            DeliveryResult deliveryResult = deliveryTool.GetCurrent();
            deliveryResult.AppliedStatusEffects.Add(statusEffect);
            deliveryResult.empty = false;
        }
    }
}
