using EnumsNew;
using Manager;
using System.Collections.Generic;
using UnityEngine;

namespace DeliverySystem
{
    public interface I_Result
    {
        void Apply(ToolManager owner, ToolManager target, List<I_Result> results);
    }
}