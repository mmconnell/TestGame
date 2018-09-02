
using Manager;
using UnityEngine;

namespace DeliverySystem
{
    public interface I_Effect
    {
        void Apply(ToolManager owner, ToolManager target, DeliveryInformation deliveryInformation, DeliveryResultPack targetDeliveryResult);
    }
}
