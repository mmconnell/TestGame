using UnityEngine;
using System.Collections;
using Enums.Trigger;
using System;

public class FireTotem : MonoBehaviour
{
    public CharacterManager CharacterManager { get; set; }
    public int FrameCount { get; set; }

    // Use this for initialization
    void Start()
    {
        Application.targetFrameRate = 60;
        CharacterManager = new CharacterManager(this);
        DerivedStatusEffect fireAura = DerivedStatusEffects.AURA_OF_FIRE_DAMAGE;
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);

        DerivedStatusEffects.BLEEDING.Apply(CharacterManager, CharacterManager, Enums.Persistance.COMBAT, 10);
        DerivedStatusEffects.BOMB.Apply(CharacterManager, CharacterManager, Enums.Persistance.COMBAT, 10);
        InvokeRepeating("TriggerTime", 1, 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CharacterManager.Trigger(CharacterTriggers.FRAME);
        FrameCount++;
        if(FrameCount >= 30)
        {
            CharacterManager.Trigger(CharacterTriggers.FRAME);
            
            FrameCount = 0;
        }
    }

    void TriggerTime()
    {
        CharacterManager.Trigger(CharacterTriggers.TURN_START);
        CharacterManager.Trigger(CharacterTriggers.TURN_END);
    }
}
