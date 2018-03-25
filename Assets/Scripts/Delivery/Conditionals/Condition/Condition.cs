using System.Collections.Generic;

namespace Delivery
{
    public abstract class Condition : Conditional
    {
        public override bool IsCondition()
        {
            return true;
        }
    }
}
