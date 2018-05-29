using System.Collections.Generic;
using UnityEngine;

namespace Delivery
{
    public class PulseCollider : MonoBehaviour
    {
        public GameObject owner;
        public float radius;
        public float growth;
        public float rate;
        public float max;
        public float width;
        public bool isNotTargetingOwner;
        public I_Effect effect;
        public Material material;
        public DeliveryResult deliveryResult;
        private HashSet<GameObject> effected;
        private CircleCollider2D circleCollider;
        private MeshFilter meshFilter;
        private LineRenderer lineRenderer;

        public void Start()
        {
            circleCollider = gameObject.AddComponent<CircleCollider2D>();
            circleCollider.radius = radius;
            effected = new HashSet<GameObject>();
            lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.useWorldSpace = false;
            //lineRenderer.loop = true;
            lineRenderer.material = material;
            circleCollider.isTrigger = true;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, radius + (width/2f));
            List<Collider2D> notToHitcolliders = new List<Collider2D>();
            float difference = radius - (width/2f);
            if (difference > 0)
            {
                notToHitcolliders.AddRange(Physics2D.OverlapCircleAll(gameObject.transform.position, difference));
            }
            Tools.MeshCreator.DrawCircle(lineRenderer, 100, radius, width);
            //meshFilter = gameObject.AddComponent<MeshFilter>();
            //meshFilter.mesh = Tools.MeshCreator.MakeCircle(10, circleCollider.radius, gameObject.transform.position);
            //MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();
            //mr.material = material;
            foreach (Collider2D collider in colliders)
            {
                if ((!isNotTargetingOwner || collider.gameObject != owner) && !notToHitcolliders.Contains(collider))
                {
                    effect.Apply(owner, collider.gameObject, deliveryResult);
                    //effected.Add(collider.gameObject);
                }
            }
            InvokeRepeating("PulseGrowth", .1f, rate);
        }

        public void PulseGrowth()
        {
            if (radius >= max)
            {
                Destroy(gameObject);
            }
            radius += growth;
            circleCollider.radius = (radius + (width/2f));
            Tools.MeshCreator.DrawCircle(lineRenderer, 100, radius, width);
        }

        public void OnTriggerEnter2D(Collider2D collider)
        {
            float difference = radius - (width/2f);
            List<Collider2D> colliders = new List<Collider2D>();
            if (difference > 0)
            {
                colliders.AddRange(Physics2D.OverlapCircleAll(gameObject.transform.position, difference));
            }
            GameObject go = collider.gameObject;
            if (!effected.Contains(go) && (!isNotTargetingOwner || collider.gameObject != owner) && !colliders.Contains(collider))
            {
                deliveryResult = new DeliveryResult();
                effect.Apply(owner, collider.gameObject, deliveryResult);
                DeliveryManager.ApplyResult(deliveryResult);
                //effected.Add(collider.gameObject);
            }
        }

        public void OnTriggerStay2D(Collider2D collider)
        {
            OnTriggerEnter2D(collider);
        }
    }
}
