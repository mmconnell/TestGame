using Delivery;
using Manager;
using UnityEngine;

public class FireTotem : MonoBehaviour
{
    public int FrameCount { get; set; }
    public bool test = true;

    // Use this for initialization
    void Start()
    {
        Application.targetFrameRate = 60;
        CreatureCreator.CreateHuman(gameObject, "Fire Totem");
        DerivedStatusEffect dse;
        /*dse = gameObject.AddComponent<OnFire>();
        dse.owner = gameObject;
        dse = gameObject.AddComponent<TimedBomb>();
        dse.duration = 10;
        dse.owner = gameObject;*/

        AuraCreator.CreateAura(gameObject, AuraCreator.CreateAuraColliderChecker(2, Resources.Load("blue", typeof(Material)) as Material), typeof(Chilled));
        AuraCreator.CreateAura(gameObject, AuraCreator.CreateAuraColliderChecker(1, Resources.Load("red", typeof(Material)) as Material), typeof(OnFire));

        //dse = gameObject.AddComponent<FirePulse>();
        //dse.owner = gameObject;

        InvokeRepeating("TriggerTime", 1, 1f);
    }

    void TriggerTime()
    {
        EventManager.TriggerEvent(gameObject, "TURN_START");
        EventManager.TriggerEvent(gameObject, "TURN_END");
    }
}
