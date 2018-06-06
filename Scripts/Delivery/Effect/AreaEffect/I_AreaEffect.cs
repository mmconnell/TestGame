using Manager;
using System.Collections.Generic;
using UnityEngine;

namespace Delivery
{
    public interface I_AreaEffect
    {
        List<ToolManager> GatherTargets(I_Position position, ToolManager source);
    }
}
