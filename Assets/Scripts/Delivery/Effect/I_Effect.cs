
using UnityEngine;

namespace Delivery
{
    public interface I_Effect
    {
        void Apply(GameObject owner, GameObject target, DeliveryResult deliveryResult);
    }
}
