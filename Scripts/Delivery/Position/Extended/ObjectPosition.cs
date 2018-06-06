using Manager;
using System;
using UnityEngine;

namespace Delivery
{
    public class ObjectPosition : I_Position
    {
        private ToolManager source;

        public ObjectPosition(ToolManager source)
        {
            if (source == null)
            {
                throw new Exception("source cannot be null");
            }
            this.source = source;
        }

        public ToolManager GetSourceObject()
        {
            return source;
        }

        public Vector2 GetSourceV2(Vector3 identity)
        {
            Vector3 transform = source.transform.position;
            Vector2 position = new Vector2();
            if (identity.x != 0 && identity.y != 0)
            {
                position.x = transform.x;
                position.y = transform.y;
            } else if (identity.x != 0 && identity.z != 0)
            {
                position.x = transform.x;
                position.y = transform.z;
            } else
            {
                position.x = transform.y;
                position.y = transform.z;
            }
            return position;
        }

        public Vector3 GetSourceV3()
        {
            return source.transform.position;
        }
    }
}
