﻿using Enums;
using UnityEngine;

namespace Delivery
{
    public class StatusEffect
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

        public void Apply(GameObject owner, GameObject target)
        {
            I_EntityManager entityOwner = InformationManager.GetManager(owner), entityTarget = InformationManager.GetManager(target);
            Apply(entityOwner, entityTarget);
            
        }

        public void Apply(I_EntityManager owner, I_EntityManager target) {
            if(target != null)
            {
                bool success = ChanceToSucceed != null ? ChanceToSucceed <= InformationManager.RandomPercent() : true;
                if (success)
                {
                    DerivedStatusEffect statusEffect = (DerivedStatusEffect)target.GameObject().AddComponent(DerivedStatusEffect.type);
                    statusEffect.duration = Duration;
                    statusEffect.owner = owner.GameObject();
                }
            }
        }
    }
}