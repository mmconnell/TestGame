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
        public bool IsNewAttack { get; set; }

        public SubDeliveryPack() { }

        public SubDeliveryPack(DeliveryPack deliveryPack, bool isNewAttack)
        {
            DeliveryPack = deliveryPack;
            IsNewAttack = isNewAttack;
        }

        public void Apply(ToolManager owner, ToolManager target)
        {
            I_Position position = new ObjectPosition(target);
            DeliveryPack.Apply(owner, position, IsNewAttack);
        }
    }
}
