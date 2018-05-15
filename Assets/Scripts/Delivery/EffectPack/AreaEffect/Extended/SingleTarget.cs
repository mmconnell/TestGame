using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Delivery
{
    class SingleTarget : I_AreaEffect
    {
        public List<I_EntityManager> GatherTargets(Vector3 position)
        {
            RaycastHit[] hits = Physics.RaycastAll(position, Vector3.zero);
            List<I_EntityManager> hitTargets = new List<I_EntityManager>();
            foreach (RaycastHit hit in hits)
            {
                I_EntityManager manager = InformationManager.GetManager(hit.collider.gameObject);
                if (manager != null)
                {
                    hitTargets.Add(manager);
                }
            }
            return hitTargets;
        }

        public List<I_EntityManager> GatherTargets(Vector2 position)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(position, Vector2.zero);
            List<I_EntityManager> hitTargets = new List<I_EntityManager>();
            foreach(RaycastHit2D hit in hits)
            {
                I_EntityManager manager = InformationManager.GetManager(hit.collider.gameObject);
                if (manager != null)
                {
                    hitTargets.Add(manager);
                }
            }
            return hitTargets;
        }
    }
}
