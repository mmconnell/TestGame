using System.Collections.Generic;

namespace Delivery
{
    public abstract class Condition : Conditional
    {
        public Conditional Conditional {get; set;}
        
        public Condition(Conditional conditional) {
            Conditional = conditional;
        }
        public override bool IsCondition()
        {
            return true;
        }
    }
}
