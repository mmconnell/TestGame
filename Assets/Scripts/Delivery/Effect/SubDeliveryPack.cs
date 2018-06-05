using Manager;
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

        public void Apply(ToolManager owner, ToolManager target, bool ignoreOwner)
        {
            I_Position position = new ObjectPosition(target);
            DeliveryPack.ignoreOwner = ignoreOwner;
            DeliveryPack.Apply(owner, position);
        }
    }
}
