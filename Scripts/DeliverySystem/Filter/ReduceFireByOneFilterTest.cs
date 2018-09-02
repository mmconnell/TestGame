using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnumsNew;
using Manager;

namespace DeliverySystem
{
    public class ReduceFireByOneFilterTest : I_Filter
    {
        public void Apply(ToolManager owner, ToolManager target, DeliveryResult deliveryResult)
        {
            if (deliveryResult.DamageDone[(int)Damage_Type_Enum.FIRE] > 0)
            {
                deliveryResult.DamageDone[(int)Damage_Type_Enum.FIRE]--;
            }
        }
    }
}
