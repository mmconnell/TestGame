using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager
{
    public class StatusEnum
    {
        public static int current = 0;

        public string value;
        public int intValue;
        public bool shouldRegister;

        public StatusEnum(string value, bool shouldRegister)
        {
            this.value = value;
            this.shouldRegister = shouldRegister;
            intValue = current;
            current++;
        }

        public StatusEnum(string value) : this(value, true) { }
    }
}
