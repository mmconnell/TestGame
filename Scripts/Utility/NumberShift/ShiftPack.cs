using System;
using System.Collections.Generic;

namespace Utility
{
    public abstract class ShiftPack
    {
        protected int baseValue;

        private List<NumberShift> shifts;
        protected NumberShift finalNumberShift;
        protected int shiftValue;

        private List<NumberShift> tempShifts;
        protected NumberShift finalTempNumberShift;

        public int FinalValue { get; protected set; }

        public ShiftPack()
        {
            shifts = new List<NumberShift>();
            tempShifts = new List<NumberShift>();
            finalNumberShift = new NumberShift();
            finalTempNumberShift = new NumberShift();
        }

        public virtual void AddShift(NumberShift numberShift)
        {
            shifts.Add(numberShift);
            finalNumberShift.Flat += numberShift.Flat;
            if (AllowMultiplier() && numberShift.Scale != 0)
            {
                finalNumberShift.Scale *= numberShift.Scale;
            }
            SetValues();
        }

        public virtual void RemoveShift(NumberShift numberShift)
        {
            shifts.Remove(numberShift);
            finalNumberShift.Flat -= numberShift.Flat;
            if (AllowMultiplier() && numberShift.Scale != 0)
            {
                finalNumberShift.Scale /= numberShift.Scale;
            }
            SetValues();
        }

        public virtual void AddBase(int value)
        {
            baseValue += value;
            SetValues();
        }

        protected virtual void CalculateShifts()
        {
            float multiplier = 1f;
            float flat = 0f;
            foreach (NumberShift ns in shifts)
            {
                flat += ns.FlatInt();
                multiplier *= ns.Scale;
            }
            if (AllowMultiplier())
            {
                finalNumberShift.Scale *= multiplier;
            }
            finalNumberShift.Flat = flat;
        }

        protected virtual void CalculateTempShifts()
        {
            float multiplier = 1f;
            float flat = 0f;
            foreach (NumberShift ns in shifts)
            {
                flat += ns.FlatInt();
                multiplier *= ns.Scale;
            }
            if (AllowMultiplier())
            {
                finalTempNumberShift.Scale *= multiplier;
            }
            finalTempNumberShift.Flat = flat;
        }

        public abstract void Calculate();
        protected abstract bool AllowMultiplier();
        protected abstract void SetValues();
    }
}
