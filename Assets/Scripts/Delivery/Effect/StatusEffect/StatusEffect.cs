using EnumsNew;
using Manager;
using UnityEngine;

namespace Delivery
{
    public class StatusEffect : I_Effect
    {
        public int? ChanceToSucceed { get; private set; }
        public DerivedStatusEffect Copy { get; private set; }
        public Persistance Persistance { get; private set; }
        public int? Duration { get; private set; }

        public StatusEffect(int chanceToSucceed, DerivedStatusEffect copy, Persistance persistance, int duration)
        {
            ChanceToSucceed = chanceToSucceed;
            Copy = copy;
            Persistance = persistance;
            Duration = duration;
        }

        public StatusEffect(int chanceToSucceed, DerivedStatusEffect copy, Persistance persistance)
        {
            ChanceToSucceed = chanceToSucceed;
            Copy = copy;
            Persistance = persistance;
            Duration = null;
        }

        public StatusEffect(DerivedStatusEffect copy, Persistance persistance, int duration)
        {
            ChanceToSucceed = null;
            Copy = copy;
            Persistance = persistance;
            Duration = duration;
        }

        public StatusEffect(DerivedStatusEffect copy, Persistance persistance)
        {
            ChanceToSucceed = null;
            Copy = copy;
            Persistance = persistance;
            Duration = null;
        }

        public void Apply(ToolManager owner, ToolManager target, bool ignoreOwner)
        {
            if (target != null && (!ignoreOwner || target != owner))
            {
                bool success = ChanceToSucceed != null ? ChanceToSucceed <= InformationManager.RandomPercent() : true;
                if (success)
                {
                    DeliveryTool deliveryTool = target.Get(DeliveryTool.toolEnum) as DeliveryTool;
                    if (deliveryTool)
                    {
                        DerivedStatusEffect statusEffect = Copy.Clone(owner, target, (Duration != null ? (int)Duration : -1));
                        DeliveryResult deliveryResult = deliveryTool.GetCurrent();
                        deliveryResult.AppliedStatusEffects.Add(statusEffect);
                    }
                }
            }
        }
    }
}
