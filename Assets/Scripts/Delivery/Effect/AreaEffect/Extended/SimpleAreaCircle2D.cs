using Manager;
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

        public List<ToolManager> GatherTargets(I_Position position, ToolManager source)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(position.GetSourceV2(new Vector3(1, 1)), Radius.GetAmount(source));
            List<ToolManager> hitTargets = new List<ToolManager>();
            foreach (Collider2D col in colliders)
            {
                GameObject go = col.gameObject;
                if (!ExcludeTarget || go != position.GetSourceObject())
                {
                    ToolManager toolManager = InformationManager.GetRegisteredToolManager(go);
                    if (toolManager)
                    {
                        hitTargets.Add(toolManager);
                    }
                }
            }
            return hitTargets;
        }
    }
}