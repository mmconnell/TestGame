using System;
using System.Collections.Generic;
using UnityEngine;

namespace Delivery
{
    class SimpleAreaCircle : I_AreaEffect
    {
        public float Radius { get; set; }

        public SimpleAreaCircle(float radius)
        {
            Radius = radius;
        }

        public List<I_EntityManager> GatherTargets(Vector3 position)
        {
            Collider[] colliders = Physics.OverlapSphere(position, Radius);
            List<I_EntityManager> hitTargets = new List<I_EntityManager>();
            foreach (Collider col in colliders)
            {
                GameObject go = col.gameObject;
                I_EntityManager manager = InformationManager.GetManager(go);
                if (manager != null)
                {
                    hitTargets.Add(manager);
                }
            }
            return hitTargets;
        }

        public List<I_EntityManager> GatherTargets(Vector2 position)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(position, Radius);
            List<I_EntityManager> hitTargets = new List<I_EntityManager>();
            foreach (Collider2D col in colliders)
            {
                GameObject go = col.gameObject;
                I_EntityManager manager = InformationManager.GetManager(go);
                if (manager != null)
                {
                    hitTargets.Add(manager);
                }
            }
            return hitTargets;
        }
    }
}