using Manager;
using UnityEngine;

namespace Delivery
{
    public interface I_Position
    {
        ToolManager GetSourceObject();
        Vector2 GetSourceV2(Vector3 identity);
        Vector3 GetSourceV3();
    }
}
