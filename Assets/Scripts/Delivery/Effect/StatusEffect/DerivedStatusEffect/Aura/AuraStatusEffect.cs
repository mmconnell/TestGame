﻿using UnityEngine;
using System;
using Manager;

namespace Delivery
{
    public class AuraStatusEffect : DerivedStatusEffect
    {
        private AuraSelector auraSelector;
        private GameObject aura;

        public AuraStatusEffect(ToolManager owner, ToolManager target, int duration, AuraSelector auraSelector) : base(owner, target, duration)
        {
            this.auraSelector = auraSelector;
            aura = auraSelector.gameObject;
            aura.transform.position = new Vector3(target.gameObject.transform.position.x, target.gameObject.transform.position.y, 1);
            aura.transform.parent = target.gameObject.transform;
            auraSelector.parent = this;
            auraSelector.Initiate();
        }

        public override string GetName()
        {
            return base.GetName();
        }

        public override void Remove()
        {
            base.Remove();
            UnityEngine.Object.Destroy(aura);
        }

        public override void Disable()
        {
            base.Disable();
            UnityEngine.Object.Destroy(aura);
        }

        public override DerivedStatusEffect Clone(ToolManager owner, ToolManager target, int duration)
        {
            return null;
        }
    }
}