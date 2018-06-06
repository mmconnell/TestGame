using UnityEngine;

public class WorldManager : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("TriggerTime", 1, 1);
    }

    private void TriggerTime()
    {
        EventManager.TriggerEvent("TIME_INSTANCE");
    }
}
