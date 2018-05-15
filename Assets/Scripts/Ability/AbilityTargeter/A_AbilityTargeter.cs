using System.Collections.Generic;
using UnityEngine;

namespace AbilityTargeter
{
    abstract class A_AbilityTargeter
    {
        public abstract List<I_EntityManager> Apply(Vector3 source);
        public abstract bool CanApply(Vector3 source);
    }
}
