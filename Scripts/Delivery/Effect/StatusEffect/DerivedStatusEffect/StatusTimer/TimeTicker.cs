using System;
using System.Collections;
using Manager;
using UnityEngine;

namespace Delivery
{
    public class TimeTicker : I_Ticker, I_Timed
    {
        public static I_Ticker Ticker = new TimeTicker();

        private I_DerivedStatus derivedStatus;
        private float? originalDuration;
        private float? duration;
        private float frequency;
        private float nextTick;
        private WaitForSeconds wfs;
        private bool enabled;
        private bool tracked;
        private bool timed;

        private TimeTicker() { }

        public TimeTicker(I_DerivedStatus status, float? duration, float frequency)
        {
            derivedStatus = status;
            originalDuration = duration;
            this.duration = duration;
            if (duration != null)
            {
                timed = true;
            }
            this.frequency = frequency;
            nextTick = frequency;
        }

        public void Disable()
        {
            if (enabled)
            {
                enabled = false;
            }
        }

        public void Enable()
        {
            if (!enabled)
            {
                enabled = true;
                if (!tracked)
                {
                    TimeManager.AddListener(this);
                }
            }
        }

        private StatusEnum[] enums = {};
        public StatusEnum[] GetStatusEnums()
        {
            return enums;
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            duration = originalDuration;
        }

        public void Trigger(StatusEnum statusEnum) {}

        public void Update(float time)
        {
            if (timed)
            {
                duration -= time;
            }
            nextTick -= time;
            if (nextTick <= 0f)
            {
                if (timed && duration < nextTick)
                {
                    float accuracyTest = nextTick - (float)duration;
                    if (accuracyTest <= .01f)
                    {
                        derivedStatus.Trigger(StatusTool.TICK);
                    }
                    nextTick = frequency + nextTick;
                }
                else
                {
                    nextTick = frequency + nextTick;
                    derivedStatus.Trigger(StatusTool.TICK);
                }
            }
            if (timed && duration <= 0f)
            {
                derivedStatus.Disable();
            }
        }

        public bool IsEnabled()
        {
            return enabled;
        }

        public void StopTracking()
        {
            tracked = false;
        }

        public void StartTracking()
        {
            tracked = true;
        }

        public bool IsTracked()
        {
            return tracked;
        }
    }
}
