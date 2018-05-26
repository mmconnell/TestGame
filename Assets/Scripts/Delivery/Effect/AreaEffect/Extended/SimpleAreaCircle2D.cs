using System.Collections.Generic;
using UnityEngine;

namespace Delivery
{
    class SimpleAreaCircle2D : I_AreaEffect
    {
        public float Radius { get; set; }

        public SimpleAreaCircle2D(float radius)
        {
            Radius = radius;
        }

        public List<GameObject> GatherTargets(I_Position position)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(position.GetSourceV2(new Vector3(1, 1)), Radius);
            List<GameObject> hitTargets = new List<GameObject>();
            foreach (Collider2D col in colliders)
            {
                GameObject go = col.gameObject;
                if (go != null)
                {
                    hitTargets.Add(go);
                }
            }
            return hitTargets;
        }
    }
}