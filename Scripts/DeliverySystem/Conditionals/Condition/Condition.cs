using EnumsNew;
using Manager;
using System.Collections.Generic;
using UnityEngine;

namespace DeliverySystem
{
    public abstract class Condition
    {
        public Conditional Conditional {get; set;}
        
        public Condition(Conditional conditional) {
            Conditional = conditional;
        }

        public abstract bool Apply(ToolManager owner, ToolManager target, List<I_Result> results);
    }
}
