using Delivery;
using EnumsNew;
using Manager;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class PlayerController : MonoBehaviour
{
    Camera myCamera;
    DeliveryPack deliveryPack;
    ToolManager toolManager;
    public Material material;

    private void Start()
    {
        deliveryPack = new DeliveryPack
        {
            AreaEffect = new SimpleAreaCircle2D(new FlatNumber(1)),
            EffectMap = new SortedDictionary<int, List<I_Effect>>
            {
                {
                    1, new List<I_Effect>
                    {
                        //new StatusEffect(OnFire.Cloner, Persistance.COMBAT, 2),
                        new DamagePack(new SimpleDamageType(Damage_Type_Enum.FIRE), new FlatNumber(110)/*new RangeNumber(new FlatNumber(10), new FlatNumber(50))*/),
                        new SubDeliveryPack
                        {
                            IsNewAttack = true,
                            DeliveryPack = new DeliveryPack
                            {
                                EffectMap = new SortedDictionary<int, List<I_Effect>>
                                {
                                    {
                                        1, new List<I_Effect>
                                        {
                                            new DamagePack(new SimpleDamageType(Damage_Type_Enum.FIRE), new FlatNumber(110)),
                                            new SubDeliveryPack
                                            {
                                                IsNewAttack = true,
                                                DeliveryPack = new DeliveryPack
                                                {
                                                    EffectMap = new SortedDictionary<int, List<I_Effect>>
                                                    {
                                                        {
                                                            1, new List<I_Effect>
                                                            {
                                                                new DamagePack(new SimpleDamageType(Damage_Type_Enum.FIRE), new FlatNumber(110)),
                                                                new SubDeliveryPack
                                                                {
                                                                    IsNewAttack = true,
                                                                    DeliveryPack = new DeliveryPack
                                                                    {
                                                                        EffectMap = new SortedDictionary<int, List<I_Effect>>
                                                                        {
                                                                            {
                                                                                1, new List<I_Effect>
                                                                                {
                                                                                    new DamagePack(new SimpleDamageType(Damage_Type_Enum.FIRE), new FlatNumber(110)),
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
        toolManager = InformationManager.GetRegisteredToolManager(gameObject);
        material = Resources.Load("red", typeof(Material)) as Material;
    }

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        if (myCamera == null)
        {
            myCamera = Camera.main;
        }

        transform.Translate(x, z, 0);
        Vector3 vector = myCamera.transform.position;
        myCamera.transform.position = new Vector3(transform.position.x, transform.position.y, vector.z);

        if (Input.GetMouseButtonUp(0))
        {
            DeliveryPack.Deliver(deliveryPack, toolManager, new GeneralPosition(gameObject.transform.position));
            GameObject area = new GameObject();
            area.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y);
            MeshFilter mf = area.AddComponent<MeshFilter>();
            mf.mesh = Tools.MeshCreator.MakeCircle(20, 1, area.transform.position);
            MeshRenderer mr = area.AddComponent<MeshRenderer>();
            mr.material = material;
            Destroy(area, 2);
        }
    }
}
