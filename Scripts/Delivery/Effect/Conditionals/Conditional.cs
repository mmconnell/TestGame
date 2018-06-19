using Manager;
using System.Collections.Generic;
using UnityEngine;

namespace Delivery
{
    public class Conditional : I_Effect
    {
        private List<Condition> Conditions { get; set; }
        private Result Result { get; set; }

        public Conditional(List<Condition> conditions, Result result)
        {
            Conditions = conditions;
            Result = result;
        }

        public void Apply(ToolManager owner, ToolManager targets, DeliveryInformation di, DeliveryResultPack targetDeliveryResult)
        {
            
        }
    }
}

