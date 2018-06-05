using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delivery
{
    public class EffectOverTime : I_BaseStatusEffect
    {
        private I_Effect effect;

        public EffectOverTime(I_Effect effect)
        {
            this.effect = effect;
        }

        public void Apply(DerivedStatusEffect dse)
        {
            //EventManager.StartListening(dse.target.gameObject, "TURN_START", TurnStart);
        }

        public void End(DerivedStatusEffect dse)
        { 
            Remove(dse);
        }

        public void Remove(DerivedStatusEffect dse)
        {
            //EventManager.StopListening(dse.target.gameObject, "TURN_START", TurnStart);
        }

        public void Trigger(DerivedStatusEffect dse, StatusEnum statusEnum)
        {
            if (statusEnum.value.Equals(StatusTool.TURN_START_STRING))
            {
                TurnStart(dse);
            }
        }

        public void TurnStart(DerivedStatusEffect dse)
        {
            effect.Apply(dse.owner, dse.target, false);
        }

        private static StatusEnum[] statusEnums = new StatusEnum[] { StatusTool.TURN_START };
        public StatusEnum[] GetStatusEnums()
        {
            return statusEnums;
        }
    }
}
