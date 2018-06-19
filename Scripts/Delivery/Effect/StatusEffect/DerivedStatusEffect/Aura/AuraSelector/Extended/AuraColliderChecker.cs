using UnityEngine;
using System;
using System.Collections.Generic;
using Manager;

namespace Delivery
{
    public class AuraColliderChecker : AuraSelector
    {
        public float radius;
        private Dictionary<GameObject, DerivedStatusEffect> attached;
        public DerivedStatusEffect AuraEffect;
        public Material material;

        public override void Initiate()
        {
            CircleCollider2D circleCollider = gameObject.AddComponent<CircleCollider2D>();
            circleCollider.radius = radius;
            MeshFilter mf = gameObject.AddComponent<MeshFilter>();
            mf.mesh = Tools.MeshCreator.MakeCircle(20, radius, gameObject.transform.position);
            MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();
            mr.material = material;
            attached = new Dictionary<GameObject, DerivedStatusEffect>();
            circleCollider.isTrigger = true;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, circleCollider.radius);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject != parent.owner.gameObject)
                {
                    ToolManager tm = InformationManager.GetRegisteredToolManager(collider.gameObject);
                    if (tm)
                    {
                        MonoBehaviour buffable = tm.Get(BuffTool.toolEnum);
                        if (buffable)
                        {
                            //DerivedStatusEffect dse = AuraEffect.Clone(parent.owner, tm, -1);
                            //attached.Add(collider.gameObject, dse);
                        }
                    }
                }
            }
        }

        public void OnTriggerEnter2D(Collider2D collider)
        {
            GameObject go = collider.gameObject;
            if (!attached.ContainsKey(go))
            {
                ToolManager tm = InformationManager.GetRegisteredToolManager(go);
                if (tm)
                {
                    MonoBehaviour buffable = tm.Get(BuffTool.toolEnum);
                    StatusTool statusTool = tm.Get(StatusTool.toolEnum) as StatusTool;
                    if (buffable)
                    {
                        //DerivedStatusEffect comp = AuraEffect.Clone(parent.owner, tm);
                        //comp.owner = parent.owner;
                        //attached.Add(go, comp);
                    }
                }
            } else
            {
                DerivedStatusEffect statusEffect = attached[go];
                if (!statusEffect.enabled)
                {
                    statusEffect.Enable();
                }
            }
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            GameObject go = collision.gameObject;
            if (attached.ContainsKey(go))
            {
                DerivedStatusEffect statusEffect = attached[go];
                statusEffect.Disable();
            }

        }

        void OnDisable()
        {
            foreach (DerivedStatusEffect dse in attached.Values)
            {
                dse.Disable();
            }
        }
    }
}