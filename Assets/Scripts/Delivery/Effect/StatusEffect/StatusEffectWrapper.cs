using EnumsNew;
using UnityEngine;

namespace Delivery
{
    public class StatusEffect : I_Effect
    {
        public int? ChanceToSucceed { get; private set; }
        public TypeWrapper DerivedStatusEffect { get; private set; }
        public Persistance Persistance { get; private set; }
        public int? Duration { get; private set; }

        public StatusEffect(int chanceToSucceed, TypeWrapper derivedStatusEffect, Persistance persistance, int duration)
        {
            ChanceToSucceed = chanceToSucceed;
            DerivedStatusEffect = derivedStatusEffect;
            Persistance = persistance;
            Duration = duration;
        }

        public StatusEffect(int chanceToSucceed, TypeWrapper derivedStatusEffect, Persistance persistance)
        {
            ChanceToSucceed = chanceToSucceed;
            DerivedStatusEffect = derivedStatusEffect;
            Persistance = persistance;
            Duration = null;
        }

        public StatusEffect(TypeWrapper derivedStatusEffect, Persistance persistance, int duration)
        {
            ChanceToSucceed = null;
            DerivedStatusEffect = derivedStatusEffect;
            Persistance = persistance;
            Duration = duration;
        }

        public StatusEffect(TypeWrapper derivedStatusEffect, Persistance persistance)
        {
            ChanceToSucceed = null;
            DerivedStatusEffect = derivedStatusEffect;
            Persistance = persistance;
            Duration = null;
        }

        public void Apply(GameObject owner, GameObject target, DeliveryResult deliveryResult)
        {
            if (target != null)
            {
                bool success = ChanceToSucceed != null ? ChanceToSucceed <= InformationManager.RandomPercent() : true;
                if (success)
                {
                    DerivedStatusEffect statusEffect = (DerivedStatusEffect)target.AddComponent(DerivedStatusEffect.type);
                    if (Duration != null)
                    {
                        statusEffect.duration = (int)Duration;
                    }
                    statusEffect.owner = owner;
                    deliveryResult.Get(target).AppliedStatusEffects.Add(statusEffect);
                }
            }
        }
    }
}
