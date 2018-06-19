using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Manager;
using UnityEngine;
using Utility;

namespace Delivery
{
    public class PullForceEffect : I_Effect
    {
        public DynamicNumber PullForce { get; set; }

        public PullForceEffect(DynamicNumber pushForce)
        {
            PullForce = pushForce;
        }

        public void Apply(ToolManager owner, ToolManager target, DeliveryInformation deliveryInformation, DeliveryResultPack targetDeliveryResult)
        {
            Rigidbody2D rb = target.rigidBody;
            if (rb)
            {
                Vector3 dir = deliveryInformation.currentPosition.GetSourceV3() - rb.transform.position;
                dir = dir.normalized;
                rb.AddForce(dir * PullForce.GetAmount(owner, target));
            }
        }
    }
}
