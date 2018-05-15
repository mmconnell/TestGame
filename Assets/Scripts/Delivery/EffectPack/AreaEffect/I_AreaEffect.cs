using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Delivery
{
    public interface I_AreaEffect
    {
        List<I_EntityManager> GatherTargets(Vector3 position);
        List<I_EntityManager> GatherTargets(Vector2 position);
    }
}
