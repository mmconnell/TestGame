using Manager;

namespace DeliverySystem
{
    public interface I_Filter
    {
        void Apply(ToolManager owner, ToolManager target, DeliveryResult deliveryResult);
    }
}
