using Manager;
using Utility;

namespace Delivery
{
    public class TurnTicker : I_Ticker
    {
        public static I_Ticker Ticker = new TurnTicker();

        I_DerivedStatus DerivedStatus;
        int originalDuration;
        int duration;
        private bool enabled;

        private TurnTicker() {}

        public TurnTicker(I_DerivedStatus status, int duration)
        {
            if (duration < 0)
            {
                originalDuration = -1;
            }
            else
            {
                originalDuration = duration;
            }
            this.duration = originalDuration;
            DerivedStatus = status;
            enabled = false;
        }

        public I_Ticker Build(I_DerivedStatus status, DynamicNumber number)
        {
            if (number == null)
            {
                return new TurnTicker(status, -1);
            }
            return new TurnTicker(status, number.GetIntAmount(status.Owner(), status.Target()));
        }

        public void Reset()
        {
            duration = originalDuration;
        }

        public void Disable()
        {
            enabled = false;
        }

        public void Enable()
        {
            enabled = true;
        }

        public void Remove() {}

        public void Trigger(StatusEnum statusEnum)
        {
            if (enabled)
            {
                switch (statusEnum.value)
                {
                    case StatusTool.TURN_END_STRING:
                        DerivedStatus.Trigger(StatusTool.TICK);
                        TurnEnd();
                        break;
                }
            }
        }

        private void TurnEnd()
        {
            if (duration > 0)
            {
                duration -= 1;
                if (duration == 0)
                {
                    DerivedStatus.Disable();
                }
            }
        }

        private static StatusEnum[] statusEnums = { StatusTool.TURN_END };
        private static StatusEnum[] noDurationEnums = { };
        public StatusEnum[] GetStatusEnums()
        {
            if (duration == -1)
            {
                return noDurationEnums;
            }
            return statusEnums;
        }
    }
}
