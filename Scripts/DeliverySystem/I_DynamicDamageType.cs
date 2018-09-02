using EnumsNew;
using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DeliverySystem
{
    public interface I_DynamicDamageType
    {
        List<KeyValuePair<Damage_Type_Enum, float>> GetDamageTypes(ToolManager target);
    }
}
