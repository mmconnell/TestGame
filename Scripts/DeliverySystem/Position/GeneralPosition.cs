using Manager;
using UnityEngine;

namespace DeliverySystem
{
    public class GeneralPosition : I_Position
    {
        Vector3 generalPosition;

        public GeneralPosition(Vector3 generalPosition)
        {
            this.generalPosition = generalPosition;
        }

        public ToolManager GetSourceObject()
        {
            return null;
        }

        public Vector2 GetSourceV2(Vector3 identity)
        {
            Vector3 transform = generalPosition;
            Vector2 position = new Vector2();
            if (identity.x != 0 && identity.y != 0)
            {
                position.x = transform.x;
                position.y = transform.y;
            }
            else if (identity.x != 0 && identity.z != 0)
            {
                position.x = transform.x;
                position.y = transform.z;
            }
            else
            {
                position.x = transform.y;
                position.y = transform.z;
            }
            return position;
        }

        public Vector3 GetSourceV3()
        {
            return generalPosition;
        }
    }
}
