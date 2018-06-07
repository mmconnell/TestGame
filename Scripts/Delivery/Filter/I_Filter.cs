using Manager;

namespace Delivery
{
    public interface I_Filter
    {
        void Apply(ToolManager owner, ToolManager target, DeliveryResult deliveryResult);
    }
}
