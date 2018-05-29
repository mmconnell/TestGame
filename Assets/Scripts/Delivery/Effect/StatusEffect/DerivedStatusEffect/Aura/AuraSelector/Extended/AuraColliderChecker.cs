using UnityEngine;
using System;
using System.Collections.Generic;
using Manager;

namespace Delivery
{
    public class AuraColliderChecker : AuraSelector
    {
        public float radius;
        private Dictionary<GameObject, Component> attached;
        public Material material;

        public override void Initiate()
        {
            CircleCollider2D circleCollider = gameObject.AddComponent<CircleCollider2D>();
            circleCollider.radius = radius;
            MeshFilter mf = gameObject.AddComponent<MeshFilter>();
            mf.mesh = Tools.MeshCreator.MakeCircle(20, radius, gameObject.transform.position);
            MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();
            mr.material = material;
            attached = new Dictionary<GameObject, Component>();
            circleCollider.isTrigger = true;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, circleCollider.radius);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject != parent.owner)
                {
                    MonoBehaviour buffable = InformationManager.GetRegisteredComponent(collider.gameObject, typeof(Buffable));
                    if (buffable)
                    {
                        DerivedStatusEffect comp = collider.gameObject.AddComponent(AuraEffect) as DerivedStatusEffect;
                        comp.owner = parent.owner;
                        attached.Add(collider.gameObject, comp);
                    }
                }
            }
        }

        public void OnTriggerEnter2D(Collider2D collider)
        {
            GameObject go = collider.gameObject;
            if (!attached.ContainsKey(go))
            {
                MonoBehaviour buffable = InformationManager.GetRegisteredComponent(collider.gameObject, typeof(Buffable));
                if (buffable)
                {
                    DerivedStatusEffect comp = go.AddComponent(AuraEffect) as DerivedStatusEffect;
                    comp.owner = parent.owner;
                    attached.Add(go, comp);
                }
            }
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            GameObject go = collision.gameObject;
            if (attached.ContainsKey(go))
            {
                Component comp = attached[go];
                Destroy(comp);
                attached.Remove(go);
            }
        }

        void OnDisable()
        {
            foreach (Component comp in attached.Values)
            {
                Destroy(comp);
            }
        }
    }
}