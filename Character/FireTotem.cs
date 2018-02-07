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
        CharacterManager = new CharacterManager(this);
        DerivedStatusEffect fireAura = DerivedStatusEffects.AURA_OF_FIRE_DAMAGE;
        fireAura.Apply(CharacterManager, CharacterManager, Enums.Persistance.WORLD, -1);
        DerivedStatusEffects.BLEEDING.Apply(CharacterManager, CharacterManager, Enums.Persistance.COMBAT, 10);
        DerivedStatusEffects.BOMB.Apply(CharacterManager, CharacterManager, Enums.Persistance.COMBAT, 10);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CharacterManager.Trigger(CharacterTriggers.FRAME);
        FrameCount++;
        if(FrameCount >= 30)
        {
            CharacterManager.Trigger(CharacterTriggers.FRAME);
            CharacterManager.Trigger(CharacterTriggers.TURN_START);
            CharacterManager.Trigger(CharacterTriggers.TURN_END);
            FrameCount = 0;
        }
    }
}
