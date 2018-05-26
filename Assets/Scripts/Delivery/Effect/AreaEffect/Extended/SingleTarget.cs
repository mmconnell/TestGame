using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Delivery
{
    class SingleTarget : I_AreaEffect
    {
        public List<GameObject> GatherTargets(I_Position position)
        {
            GameObject go = position.GetSourceObject();
            if (go == null)
            {
                return new List<GameObject>();
            }
            List<GameObject> list = new List<GameObject>();
            list.Add(go);
            return list;
        }
    }
}
