using EnumsNew;
using Manager;

namespace Delivery
{
    public class StatusEffect : I_Effect
    {
        public I_DerivedStatus Copy { get; set; }
        public Persistance Persistance { get; set; }
        public I_TickerPack TickerPack { get; set; }

        public StatusEffect(I_DerivedStatus copy, Persistance persistance, I_TickerPack tickerPack)
        {
            Copy = copy;
            Persistance = persistance;
            TickerPack = tickerPack;
        }

        public StatusEffect(I_DerivedStatus copy, Persistance persistance)
        {
            Copy = copy;
            Persistance = persistance;
        }

        public void Apply(ToolManager owner, ToolManager target, DeliveryInformation di, DeliveryResultPack targetResultPack)
        {
            I_DerivedStatus statusEffect = Copy.Clone(owner, target);
            if (TickerPack != null)
            {
                statusEffect.SetTicker(TickerPack.Build(statusEffect));
            }
            DeliveryResult deliveryResult = targetResultPack.GetCurrent();
            deliveryResult.AppliedStatusEffects.Add(statusEffect);
            deliveryResult.empty = false;
        }
    }
}
