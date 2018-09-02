using Manager;
using System.Collections.Generic;

namespace DeliverySystem
{
    public class Conditional : I_Effect
    {
        private List<Condition> Conditions { get; set; }
        private I_Result Result { get; set; }

        public Conditional(List<Condition> conditions, I_Result result)
        {
            Conditions = conditions;
            Result = result;
        }

        public void Apply(ToolManager owner, ToolManager targets, DeliveryInformation di, DeliveryResultPack targetDeliveryResult)
        {
            
        }
    }
}

