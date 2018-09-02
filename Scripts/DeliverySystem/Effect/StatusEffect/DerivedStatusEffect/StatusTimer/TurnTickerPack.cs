using Utility;

namespace DeliverySystem
{
    public class TurnTickerPack : I_TickerPack
    {
        private DynamicNumber duration;

        public TurnTickerPack(DynamicNumber duration)
        {
            this.duration = duration;
        }

        public I_Ticker Build(I_DerivedStatus derivedStatus)
        {
            return new TurnTicker(derivedStatus, duration.GetIntAmount(derivedStatus.Owner(), derivedStatus.Target()));
        }
    }
}
