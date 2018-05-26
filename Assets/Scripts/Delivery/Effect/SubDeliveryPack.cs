using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Delivery
{
    public class SubDeliveryPack : I_Effect
    {
        public DeliveryPack DeliveryPack { get; set; }

        public SubDeliveryPack(DeliveryPack deliveryPack)
        {
            DeliveryPack = deliveryPack;
        }

        public void Apply(GameObject owner, GameObject target, DeliveryResult deliveryResult)
        {
            I_Position position = new ObjectPosition(target);
            DeliveryPack.Apply(owner, position, deliveryResult);
        }
    }
}
