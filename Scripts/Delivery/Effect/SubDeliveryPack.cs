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
        public I_DeliveryPack DeliveryPack { get; set; }
        public bool IsNewAttack { get; set; }
        public bool CanTargetOwner { get; set; }

        public SubDeliveryPack() { }

        public SubDeliveryPack(I_DeliveryPack deliveryPack, bool isNewAttack)
        {
            DeliveryPack = deliveryPack;
            IsNewAttack = isNewAttack;
        }

        public void Apply(ToolManager owner, ToolManager target, DeliveryInformation di, DeliveryResultPack targetDeliveryResult)
        {
            di.canTargetOwner = CanTargetOwner;
            I_Position position = new ObjectPosition(target);
            DeliveryPack.Apply(owner, position, di, IsNewAttack);
        }
    }
}
