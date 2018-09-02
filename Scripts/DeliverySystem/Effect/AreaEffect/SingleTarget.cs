using Manager;
using System.Collections.Generic;
using UnityEngine;

namespace DeliverySystem
{
    class SingleTarget : I_AreaEffect
    {
        public List<ToolManager> GatherTargets(I_Position position, ToolManager source)
        {
            ToolManager go = position.GetSourceObject();
            if (go == null)
            {
                return new List<ToolManager>();
            }
            return new List<ToolManager>(){go};
        }
    }
}
