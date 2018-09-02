using Manager;
using System.Collections.Generic;

namespace DeliverySystem
{
    public class DeliveryUtility
    {
        public static I_AreaEffect SINGLE_TARGET_EFFECT = new SingleTarget();

        public static void Deliver(I_DeliveryPack deliveryPack, ToolManager owner, I_Position position)
        {
            DeliveryInformation deliveryInformation = new DeliveryInformation
            {
                packInfo = new Dictionary<ToolManager, DeliveryResultPack>()
            };
            Deliver(deliveryPack, owner, deliveryInformation, position);
        }

        public static void Deliver(I_DeliveryPack deliveryPack, ToolManager owner, DeliveryInformation deliveryInformation, I_Position position)
        {
            deliveryPack.Apply(owner, position, deliveryInformation, true);
            DeliveryTool ownerDT = owner.Get(DeliveryTool.toolEnum) as DeliveryTool;
            foreach (DeliveryResultPack drp in deliveryInformation.packInfo.Values)
            {
                drp.Deliver();
            }
            ownerDT.ToDeliver.Clear();
        }
    }
}
