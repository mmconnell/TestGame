using Manager;
using System.Collections.Generic;

namespace Delivery
{
    public class EffectOverTime : I_BaseStatusEffect
    {
        private I_DeliveryPack effect;
        private DeliveryInformation deliveryInformation;

        public EffectOverTime(I_Effect effect)
        {
            this.effect = new DeliveryPackEffect
            {
                AreaEffect = new SingleTarget(),
                Effect = effect
            };
            deliveryInformation = new DeliveryInformation
            {
                canTargetOwner = true,
                packInfo = new Dictionary<ToolManager, DeliveryResultPack>()
            };
        }

        public void Apply(DerivedStatusEffect dse){}

        public void End(DerivedStatusEffect dse)
        { 
            Remove(dse);
        }

        public void Remove(DerivedStatusEffect dse){}

        public void Trigger(DerivedStatusEffect dse, StatusEnum statusEnum)
        {
            if (statusEnum.value.Equals(StatusTool.TICK_STRING))
            {
                Tick(dse);
            }
        }

        private void Tick(DerivedStatusEffect dse)
        {
            deliveryInformation.packInfo.Clear();
            DeliveryUtility.Deliver(effect, dse.owner, deliveryInformation, dse.target.position);
        }

        private static StatusEnum[] statusEnums = new StatusEnum[] { StatusTool.TICK };
        public StatusEnum[] GetStatusEnums()
        {
            return statusEnums;
        }
    }
}
