using UnityEngine;
using DeliverySystem;
using Manager;

public class PoorGuy : MonoBehaviour
{
    public int FrameCount { get; set; }
    StatusTool statusTool;
    ToolManager tm;

    // Use this for initialization
    void Start()
    {
        CreatureCreator.CreateHuman(gameObject, "Poor John");
        statusTool = gameObject.GetComponent<StatusTool>();
        gameObject.AddComponent<PlayerController>();
        tm = InformationManager.GetRegisteredToolManager(gameObject);
        DeliveryTool dt = tm.Get(DeliveryTool.toolEnum) as DeliveryTool;
        dt.AttackFilters.Add(new ReduceFireByOneFilterTest());
        for (int x = 0; x < 1; x++)
        {
            //OnFire.Cloner.Clone(tm, tm, -1).Enable();
        }
        /*DerivedStatusEffect dse = gameObject.AddComponent<OnFire>();
        dse.duration = 5;*/

        InvokeRepeating("TriggerTime", 1, 1f);
        //EventManager.StartListening("TIME_INSTANCE", TriggerTime);
    }

    void TriggerTime()
    {
        statusTool.Trigger(StatusTool.TURN_START);
        statusTool.Trigger(StatusTool.TURN_END);
        EventManager.TriggerEvent(gameObject, "TURN_START");
        EventManager.TriggerEvent(gameObject, "TURN_END");
    }
}
