using DeliverySystem;
using EnumsNew;
using Manager;
using System.Collections.Generic;

namespace DeliverySystem
{
    public class TriggeredStatusEffect : I_BaseStatusEffect
    {
        public Character_Trigger_Enum CharacterTrigger { get; set; }
        public I_DeliveryPack DeliveryPack { get; set; }
        private DeliveryInformation deliveryInformation;
        private StatusEnum[] statusEnums;

        public TriggeredStatusEffect(Character_Trigger_Enum statusTrigger, I_DeliveryPack deliveryPack, params StatusEnum[] statusEnums)
        {
            CharacterTrigger = statusTrigger;
            DeliveryPack = deliveryPack;
            this.statusEnums = statusEnums;
            deliveryInformation = new DeliveryInformation
            {
                canTargetOwner = true,
                packInfo = new Dictionary<ToolManager, DeliveryResultPack>()
            };
        }

        public void Apply(DerivedStatusEffect dse) { }

        public void Remove(DerivedStatusEffect dse) { }

        public void End(DerivedStatusEffect dse)
        {
            Remove(dse);
        }

        public void Trigger(DerivedStatusEffect dse, StatusEnum statusEnum)
        {
            for (int x = 0; x < statusEnums.Length; x++)
            {
                if (statusEnum == statusEnums[x])
                {
                    DeliveryUtility.Deliver(DeliveryPack, dse.owner, dse.target.position);
                    break;
                }
            }
        }

        public StatusEnum[] GetStatusEnums()
        {
            return statusEnums;
        }
    }
}