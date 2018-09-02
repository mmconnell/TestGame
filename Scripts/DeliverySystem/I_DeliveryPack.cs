using Manager;

namespace DeliverySystem
{
    public interface I_DeliveryPack
    {
        void Apply(ToolManager owner, I_Position position, DeliveryInformation di, bool isNewAttack);
    }
}
