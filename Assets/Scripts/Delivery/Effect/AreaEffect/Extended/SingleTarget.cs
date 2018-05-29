using System.Collections.Generic;
using UnityEngine;

namespace Delivery
{
    class SingleTarget : I_AreaEffect
    {
        public List<GameObject> GatherTargets(I_Position position, GameObject source)
        {
            GameObject go = position.GetSourceObject();
            if (go == null)
            {
                return new List<GameObject>();
            }
            return new List<GameObject>(){go};
        }
    }
}
