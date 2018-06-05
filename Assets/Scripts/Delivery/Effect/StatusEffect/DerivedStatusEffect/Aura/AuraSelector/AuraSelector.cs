using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Delivery
{
    public abstract class AuraSelector : MonoBehaviour
    {
        public AuraStatusEffect parent;

        public abstract void Initiate();
    }
}
