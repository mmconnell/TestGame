using UnityEngine;
using Delivery;
using Manager;

public class PoorGuy : MonoBehaviour
{
    public CharacterManager CharacterManager { get; set; }
    public int FrameCount { get; set; }

    // Use this for initialization
    void Start()
    {
        CreatureCreator.CreateHuman(gameObject, "Poor John");
        /*DerivedStatusEffect dse = gameObject.AddComponent<OnFire>();
        dse.duration = 5;*/

        InvokeRepeating("TriggerTime", 1, 1f);
        //EventManager.StartListening("TIME_INSTANCE", TriggerTime);
    }

    void TriggerTime()
    {
        EventManager.TriggerEvent(gameObject, "TURN_START");
        EventManager.TriggerEvent(gameObject, "TURN_END");
    }
}
