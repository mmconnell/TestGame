using Manager;

namespace DeliverySystem
{
    public interface I_Ticker
    {
        void Reset();
        void Enable();
        void Disable();
        void Remove();
        void Trigger(StatusEnum statusEnum);
        StatusEnum[] GetStatusEnums();
    }
}
