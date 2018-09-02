using DeliverySystem;
using EnumsNew;
using Manager;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class PlayerController : MonoBehaviour
{
    Camera myCamera;
    I_DeliveryPack deliveryPack;
    ToolManager toolManager;
    public Material material;

    private void Start()
    {
        deliveryPack = new PriorityDeliveryPack
        {
            AreaEffect = new SimpleAreaCircle2D(new FlatNumber(1)),
            EffectMap = new Dictionary<int, List<I_Effect>>
            {
                {
                    1, new List<I_Effect>
                    {
                        new StatusEffect(OnFire.Cloner, Persistance.COMBAT, new TurnTickerPack(new FlatNumber(1))),
                        new DamagePack(new SimpleDamageType(Damage_Type_Enum.FIRE), new FlatNumber(100)/*new RangeNumber(new FlatNumber(10), new FlatNumber(50))*/),
                        new SubDeliveryPack
                        {
                            IsNewAttack = true,
                            DeliveryPack = new PriorityDeliveryPack
                            {
                                EffectMap = new Dictionary<int, List<I_Effect>>
                                {
                                    {
                                        1, new List<I_Effect>
                                        {
                                            new DamagePack(new SimpleDamageType(Damage_Type_Enum.FIRE), new FlatNumber(100)),
                                            new SubDeliveryPack
                                            {
                                                IsNewAttack = true,
                                                DeliveryPack = new PriorityDeliveryPack
                                                {
                                                    EffectMap = new Dictionary<int, List<I_Effect>>
                                                    {
                                                        {
                                                            1, new List<I_Effect>
                                                            {
                                                                new DamagePack(new SimpleDamageType(Damage_Type_Enum.FIRE), new FlatNumber(100)),
                                                                new SubDeliveryPack
                                                                {
                                                                    IsNewAttack = true,
                                                                    DeliveryPack = new PriorityDeliveryPack
                                                                    {
                                                                        EffectMap = new Dictionary<int, List<I_Effect>>
                                                                        {
                                                                            {
                                                                                1, new List<I_Effect>
                                                                                {
                                                                                    new DamagePack(new SimpleDamageType(Damage_Type_Enum.FIRE), new FlatNumber(100)),
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            },
        };
        deliveryPack = new PriorityDeliveryPack
        {
            AreaEffect = new SingleTarget(),
            EffectMap = new Dictionary<int, List<I_Effect>>
            {
                {
                    1, new List<I_Effect>
                    {
                        new DamagePack(new SimpleDamageType(Damage_Type_Enum.SHOCK), new FlatNumber(10)),
                        new SubDeliveryPack
                        {
                            IsNewAttack = true, 
                            DeliveryPack = new PriorityDeliveryPack
                            {
                                AreaEffect = new SimpleAreaCircle2D(new FlatNumber(1)),
                                EffectMap = new Dictionary<int, List<I_Effect>>
                                {
                                    {
                                        1, new List<I_Effect>
                                        {
                                            new DamagePack(new SimpleDamageType(Damage_Type_Enum.SHOCK), new FlatNumber(100)),
                                            new PullForceEffect(new RangeNumber(new FlatNumber(5), new FlatNumber(10))),
                                            new StatusEffect(OnFire.Cloner, Persistance.COMBAT, new TurnTickerPack(new FlatNumber(1)))
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        };
        deliveryPack = new DeliveryPackEffect
        {
            AreaEffect = new SimpleAreaCircle2D(new FlatNumber(1)),
            Effect = new StatusEffect(Chilled.Cloner, Persistance.COMBAT, /*new TurnTickerPack(new FlatNumber(2))*/ new TimeTickerPack(new FlatNumber(10f), new FlatNumber(1f)))
        };
        toolManager = InformationManager.GetRegisteredToolManager(gameObject);
        material = Resources.Load("red", typeof(Material)) as Material;
    }

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * TimeManager.GetDeltaTime() * 3.0f;
        var z = Input.GetAxis("Vertical") * TimeManager.GetDeltaTime() * 3.0f;
        if (myCamera == null)
        {
            myCamera = Camera.main;
        }

        transform.Translate(x, z, 0);
        Vector3 vector = myCamera.transform.position;
        myCamera.transform.position = new Vector3(transform.position.x, transform.position.y, vector.z);

        if (Input.GetMouseButtonUp(0) && !TimeManager.IsPaused())
        {
            GameObject area = new GameObject();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            area.transform.position = transform.position;//new Vector3(ray.origin.x, ray.origin.y);
            DeliveryInformation di = new DeliveryInformation
            {
                packInfo = new Dictionary<ToolManager, DeliveryResultPack>(),
                canTargetOwner = true,
            };
            DeliveryUtility.Deliver(deliveryPack, toolManager, di, new ObjectPosition(toolManager));
            MeshFilter mf = area.AddComponent<MeshFilter>();
            mf.mesh = Tools.MeshCreator.MakeCircle(20, 1, area.transform.position);
            MeshRenderer mr = area.AddComponent<MeshRenderer>();
            mr.material = material;
            Destroy(area, 2);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TimeManager.Pause();
        }
    }
}
