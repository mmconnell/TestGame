using System.Collections.Generic;
using UnityEngine;

namespace Delivery
{
    public class DeliveryResult
    {
        private Dictionary<GameObject, SubDeliveryResult> results;

        public DeliveryResult()
        {
            results = new Dictionary<GameObject, SubDeliveryResult>();
        }

        public SubDeliveryResult Get(GameObject go)
        {
            SubDeliveryResult result = null;
            if (results.TryGetValue(go, out result))
            {
                return result;
            }
            else
            {
                result = new SubDeliveryResult();
                results.Add(go, result);
                return result;
            }
        }

        public Dictionary<GameObject, SubDeliveryResult> GetResults()
        {
            return results;
        }
    }
}
