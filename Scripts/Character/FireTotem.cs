using Delivery;
using EnumsNew;
using Manager;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class FireTotem : MonoBehaviour
{
    public int FrameCount { get; set; }
    public bool test = true;
    public EffectOverTime dot;
    DerivedStatusEffect dse;
    TurnManager turnTool;
    DeliveryTool dt;
    I_Filter filter;
    DynamicNumber random = new RangeNumber(new FlatNumber(1), new FlatNumber(5));

    // Use this for initialization
    void Start()
    {
        Application.SetStackTraceLogType(LogType.Log, StackTraceLogType.None);
        //Application.targetFrameRate = 60;
        CreatureCreator.CreateHuman(gameObject, "Fire Totem");
        ToolManager toolManager = gameObject.GetComponent<ToolManager>();
        dt = toolManager.Get(DeliveryTool.toolEnum) as DeliveryTool;
        if (filter == null)
        {
            filter = new ReduceFireByOneFilterTest();
        }
        // DerivedStatusEffect dse;
        DynamicNumber dynamicNumber = new RangeNumber(new FlatNumber(1), new FlatNumber(5));
        gameObject.transform.position = new Vector3(dynamicNumber.GetAmount(toolManager), dynamicNumber.GetAmount(toolManager));
        for (int x = 0; x < 100; x++)
        {
            //dt.AttackFilters.Add(filter);
            //OnFire.Create(toolManager, toolManager, -1);
            //dse = gameObject.AddComponent<OnFire>();
            //dse.owner = toolManager;
            //dse.duration = dynamicNumber.GetIntAmount(toolManager, toolManager);
        }
        //OnFire.Cloner.Clone(toolManager, toolManager, -1).Enable();

        /*dse = gameObject.AddComponent<TimedBomb>();
        dse.duration = 10;
        dse.owner = gameObject;*/

        //AuraCreator.CreateAura(toolManager, AuraCreator.CreateAuraColliderChecker(2, Chilled.Cloner, Resources.Load("blue", typeof(Material)) as Material));
        //AuraCreator.CreateAura(gameObject, AuraCreator.CreateAuraColliderChecker(2, typeof(Chilled), Resources.Load("blue", typeof(Material)) as Material));
        //AuraCreator.CreateAura(gameObject, AuraCreator.CreateAuraColliderChecker(2, typeof(Chilled), Resources.Load("blue", typeof(Material)) as Material));
        //AuraStatusEffect ase = AuraCreator.CreateAura(toolManager, AuraCreator.CreateAuraColliderChecker(1, typeof(OnFire), Resources.Load("red", typeof(Material)) as Material));
        //ase.duration = 1;
        //dse = gameObject.AddComponent<EarthQuake>();
        //dse.owner = gameObject;

        //dse = gameObject.AddComponent<FirePulse>();
        //dse.owner = gameObject;

        turnTool = toolManager.Get(TurnManager.toolEnum) as TurnManager;
        //InvokeRepeating("TriggerTime", Random.value * random.GetAmount(toolManager) , 1f);
    }

    public void TriggerTime()
    {
        StartCoroutine(turnTool.TakeTurn());
    }
}
