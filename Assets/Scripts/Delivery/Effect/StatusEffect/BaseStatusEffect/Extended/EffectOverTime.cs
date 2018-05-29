using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delivery
{
    public class EffectOverTime : I_BaseStatusEffect
    {
        private I_Effect effect;
        private DerivedStatusEffect derivedStatusEffect;

        public EffectOverTime(DerivedStatusEffect derivedStatusEffect, I_Effect effect)
        {
            this.effect = effect;
            this.derivedStatusEffect = derivedStatusEffect;
        }

        public void Apply()
        {
            EventManager.StartListening(derivedStatusEffect.target, "TURN_START", TurnStart);
        }

        public void End()
        {
            Remove();
        }

        public void Remove()
        {
            EventManager.StopListening(derivedStatusEffect.target, "TURN_START", TurnStart);
        }

        public void TurnStart()
        {
            DeliveryResult deliveryResult = new DeliveryResult();
            effect.Apply(derivedStatusEffect.owner, derivedStatusEffect.target, deliveryResult);
            deliveryResult.GetResults().Clear();
        }
    }
}
