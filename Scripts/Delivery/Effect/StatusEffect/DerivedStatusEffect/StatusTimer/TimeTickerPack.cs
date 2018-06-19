using Utility;

namespace Delivery
{
    public class TimeTickerPack : I_TickerPack
    {
        private DynamicNumber duration;
        private DynamicNumber frequency;

        public TimeTickerPack(DynamicNumber duration, DynamicNumber frequency)
        {
            this.duration = duration;
            this.frequency = frequency;
        }

        public I_Ticker Build(I_DerivedStatus derivedStatus)
        {
            if (duration == null)
            {
                return new TimeTicker(derivedStatus, null, frequency.GetAmount(derivedStatus.Owner(), derivedStatus.Target()));
            }
            return new TimeTicker(derivedStatus, duration.GetAmount(derivedStatus.Owner(), derivedStatus.Target()), frequency.GetAmount(derivedStatus.Owner(), derivedStatus.Target()));
        }
    }
}
