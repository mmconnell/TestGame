﻿using UnityEngine;
using System.Collections;
using Enums.Trigger;

public class PoorGuy : MonoBehaviour
{
    public CharacterManager CharacterManager { get; set; }
    public int FrameCount { get; set; }

    // Use this for initialization
    void Start()
    {
        CharacterManager = GetComponent<CharacterManager>();
        InvokeRepeating("TriggerTime", 1, 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CharacterManager.Trigger(CharacterTriggers.FRAME);
        FrameCount++;
        if (FrameCount%30 == 0)
        {
            
            //CharacterManager.Trigger(CharacterTriggers.TURN_START);
            //CharacterManager.Trigger(CharacterTriggers.TURN_END);
            FrameCount = 0;
        }
    }

    void TriggerTime()
    {
        EventManager.TriggerEvent(CharacterManager, "TURN_START");
        EventManager.TriggerEvent(CharacterManager, "TURN_END");
        CharacterManager.Trigger(CharacterTriggers.TURN_START);
        CharacterManager.Trigger(CharacterTriggers.TURN_END);
    }
}
