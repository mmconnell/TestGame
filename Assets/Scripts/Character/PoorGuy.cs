﻿using UnityEngine;
using Delivery;
using Manager;

public class PoorGuy : MonoBehaviour
{
    public int FrameCount { get; set; }
    StatusTool statusTool;

    // Use this for initialization
    void Start()
    {
        CreatureCreator.CreateHuman(gameObject, "Poor John");
        statusTool = gameObject.GetComponent<StatusTool>();
        gameObject.AddComponent<PlayerController>();
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