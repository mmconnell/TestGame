using UnityEngine;

namespace DeliverySystem
{
    public abstract class AuraSelector : MonoBehaviour
    {
        public AuraStatusEffect parent;

        public abstract void Initiate();
    }
}
