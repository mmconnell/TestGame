using UnityEngine;
using System.Collections;
using Enums.Trigger;
using System;

public class FireTotem : MonoBehaviour
{
    public CharacterManager CharacterManager { get; set; }
    public int FrameCount { get; set; }
    public bool test = true;

    // Use this for initialization
    void Start()
    {
        Application.targetFrameRate = 60;
        CharacterManager = GetComponent<CharacterManager>();
        //CharacterManager = new CharacterManager(this);
        /*DerivedStatusEffect fireAura = DerivedStatusEffects.AURA_OF_FIRE_DAMAGE;
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
        DerivedStatusEffects.BOMB.Apply(CharacterManager, CharacterManager, Enums.Persistance.COMBAT, 10);*/
        GameObject go = GameObject.Find("poorGuy");
        Chilled c = go.AddComponent<Chilled>();
        c.duration = 10;
        c.owner = gameObject;
        AuraStatusEffect aura1 = gameObject.AddComponent<AuraStatusEffect>();
        aura1.auraEffect = typeof(Chilled);
        aura1.radius = 1;
        aura1.owner = gameObject;
        AuraStatusEffect aura2 = gameObject.AddComponent<AuraStatusEffect>();
        aura2.auraEffect = typeof(OnFire2);
        aura2.radius = 1;
        aura2.owner = gameObject;
        TimedBomb tb = gameObject.AddComponent<TimedBomb>();
        tb.duration = 5;
        tb.owner = gameObject;
        
        EventManager.StartListening("TIME_INSTANCE", TriggerTime);
        InvokeRepeating("TriggerTime", 1, 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(test)
        {
            TestScript ts = GameObject.Find("poorGuy").AddComponent<TestScript>();
            ts.num = 1;
            test = false;
        }
        //CharacterManager.Trigger(CharacterTriggers.FRAME);
        //FrameCount++;
        if(FrameCount >= 30)
        {
       //     CharacterManager.Trigger(CharacterTriggers.FRAME);
            
       //     FrameCount = 0;
        }
    }

    void TriggerTime()
    {
        EventManager.TriggerEvent(gameObject, "TURN_START");
        EventManager.TriggerEvent(gameObject, "TURN_END");
    }
}
