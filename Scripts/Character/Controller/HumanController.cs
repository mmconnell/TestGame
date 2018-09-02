using DeliverySystem;
using EnumsNew;
using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class HumanController : CharacterController
{
    private I_DeliveryPack deliveryPack;
    private Camera myCamera;
    private ToolManager toolManager;
    private Material material;

    public override void Awake()
    {
        base.Awake();
        deliveryPack = new DeliveryPackEffect
        {
            AreaEffect = new SimpleAreaCircle2D(new FlatNumber(1)),
            Effect = new StatusEffect(Chilled.Cloner, Persistance.COMBAT, new TurnTickerPack(new FlatNumber(2)) /*new TimeTickerPack(new FlatNumber(10f), new FlatNumber(1f))*/)
        };
        myCamera = Camera.main;
        toolManager = InformationManager.GetRegisteredToolManager(gameObject);
        material = Resources.Load("red", typeof(Material)) as Material;
    }

    public override IEnumerator TakeTurn()
    {
        isTurn = true;
        while (isTurn)
        {
            var x = Input.GetAxis("Horizontal") * TimeManager.GetDeltaTime() * 3.0f;
            var z = Input.GetAxis("Vertical") * TimeManager.GetDeltaTime() * 3.0f;

            transform.Translate(x, z, 0);
            Vector3 vector = myCamera.transform.position;
            myCamera.transform.position = new Vector3(transform.position.x, transform.position.y, vector.z);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TimeManager.Pause();
            }
            if (Input.GetMouseButtonUp(0) && !TimeManager.IsPaused())
            {
                GameObject area = new GameObject();
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                area.transform.position = transform.position;
                DeliveryInformation di = new DeliveryInformation
                {
                    packInfo = new Dictionary<ToolManager, DeliveryResultPack>(),
                    canTargetOwner = false,
                };
                DeliveryUtility.Deliver(deliveryPack, toolManager, di, new ObjectPosition(toolManager));
                MeshFilter mf = area.AddComponent<MeshFilter>();
                mf.mesh = Tools.MeshCreator.MakeCircle(20, 1, area.transform.position);
                MeshRenderer mr = area.AddComponent<MeshRenderer>();
                mr.material = material;
                Destroy(area, 2);
                isTurn = false;
            }
            if (Input.GetMouseButtonUp(1) && !TimeManager.IsPaused())
            {
                isTurn = false;
            }
            yield return null;
        }
    }
}
