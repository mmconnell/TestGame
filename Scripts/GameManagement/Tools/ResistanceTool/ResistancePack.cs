using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager
{
    public class ResistancePack
    {
        int baseValue;
        List<NumberShift> shifts;
        public int CurrentValue { get; private set; }

        public ResistancePack()
        {
            shifts = new List<NumberShift>();
        }

        public void AddShift(NumberShift numberShift)
        {
            shifts.Add(numberShift);
            CurrentValue += numberShift.FlatInt();
        }

        public void RemoveShift(NumberShift numberShift)
        {
            shifts.Remove(numberShift);
            CurrentValue -= numberShift.FlatInt();
        }

        public void AddBase(int value)
        {
            baseValue += value;
            CurrentValue += value;
        }

        public void Calculate()
        {
            CurrentValue = baseValue;
            foreach (NumberShift ns in shifts)
            {
                CurrentValue += ns.FlatInt();
            }
        }
    }
}
