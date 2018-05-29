using System.Collections.Generic;
using UnityEngine;

namespace Delivery
{
    public interface I_AreaEffect
    {
        List<GameObject> GatherTargets(I_Position position, GameObject source);
    }
}
