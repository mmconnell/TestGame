using System.Collections.Generic;
using UnityEngine;

namespace AbilityTargeter
{
    abstract class A_AbilityTargeter
    {
        public abstract List<GameObject> Apply(Vector3 source);
        public abstract bool CanApply(Vector3 source);
    }
}
