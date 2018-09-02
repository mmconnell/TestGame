using System;

namespace Utility
{
    public class FlatShiftPack : ShiftPack
    {
        private int baseMin;
        private bool hasBaseMin;
        private int baseMax;
        private bool hasBaseMax;
        private int finalMin;
        private bool hasFinalMin;
        private int finalMax;
        private bool hasFinalMax;

        public FlatShiftPack(int baseMin, int baseMax, int finalMin, int finalMax) : base()
        {
            this.baseMin = baseMin;
            hasBaseMin = true;
            this.baseMax = baseMax;
            hasBaseMax = true;
            this.finalMin = finalMin;
            hasFinalMin = true;
            this.finalMax = finalMax;
            hasFinalMax = true;
        }

        public FlatShiftPack() : base() {}

        protected override bool AllowMultiplier()
        {
            return false;
        }

        public override void Calculate()
        {
            CalculateShifts();
            CalculateTempShifts();
            SetValues();
        }

        protected override void SetValues()
        {
            shiftValue = baseValue + finalNumberShift.FlatInt();
            if (hasBaseMax)
            {
                shiftValue = Math.Min(shiftValue, baseMax);
            }
            if (hasBaseMin)
            {
                shiftValue = Math.Max(shiftValue, baseMin);
            }
            FinalValue = shiftValue + finalTempNumberShift.FlatInt();
            if (hasFinalMax)
            {
                FinalValue = Math.Min(FinalValue, finalMax);
            }
            if (hasFinalMin)
            {
                FinalValue = Math.Max(FinalValue, finalMin);
            }
        }
    }
}
