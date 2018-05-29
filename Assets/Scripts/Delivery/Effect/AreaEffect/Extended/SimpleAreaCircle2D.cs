using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Delivery
{
    class SimpleAreaCircle2D : I_AreaEffect
    {
        public DynamicNumber Radius { get; set; }
        public bool ExcludeTarget { get; set; }

        public SimpleAreaCircle2D(DynamicNumber radius)
        {
            Radius = radius;
        }

        public SimpleAreaCircle2D(DynamicNumber radius, bool excludeSource)
        {
            Radius = radius;
            ExcludeTarget = excludeSource;
        }

        public List<GameObject> GatherTargets(I_Position position, GameObject source)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(position.GetSourceV2(new Vector3(1, 1)), Radius.GetAmount(source));
            List<GameObject> hitTargets = new List<GameObject>();
            foreach (Collider2D col in colliders)
            {
                GameObject go = col.gameObject;
                if (!ExcludeTarget || go != position.GetSourceObject())
                {
                    if (go != null)
                    {
                        hitTargets.Add(go);
                    }
                }
            }
            return hitTargets;
        }
    }
}