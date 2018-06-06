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

        public StatusEnum(string value)
        {
            this.value = value;
            intValue = current;
            current++;
        }
    }
}
