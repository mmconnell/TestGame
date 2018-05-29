using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Utility
{
    public abstract class DynamicNumber
    {
        public abstract float GetAmount(GameObject owner, GameObject target);
        public abstract float GetAmount(GameObject source);

        public int GetIntAmount(GameObject owner, GameObject target)
        {
            return (int)GetAmount(owner, target);
        }

        public int GetIntAmount(GameObject source)
        {
            return (int)GetAmount(source);
        }
    }
}
