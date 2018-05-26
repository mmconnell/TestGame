using Delivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    private static DeliveryManager deliveryManager;

    private static DeliveryManager Instance
    {
        get
        {
            if (!deliveryManager)
            {
                deliveryManager = FindObjectOfType(typeof(DeliveryManager)) as DeliveryManager;

                if (!deliveryManager)
                {
                    Debug.LogError("There needs to be one active InformationManager script on a GameObject in your scene.");
                }
                else
                {
                    deliveryManager.Init();
                }
            }

            return deliveryManager;
        }
    }

    protected virtual void Init()
    {
    }

    public static void Run(GameObject owner, I_Position position, DeliveryPack deliveryPack)
    {
        Instance.RunMethod(owner, position, deliveryPack);
    }

    protected virtual void RunMethod(GameObject owner, I_Position position, DeliveryPack deliveryPack)
    {
        DeliveryResult deliveryResult = new DeliveryResult();
        deliveryPack.Apply(owner, position, deliveryResult);
    }

    public static void ApplyResult(DeliveryResult deliveryResult)
    {
        Instance.ApplyResultMethod(deliveryResult);
    }

    protected virtual void ApplyResultMethod(DeliveryResult deliveryResult)
    {
        foreach (KeyValuePair<GameObject, SubDeliveryResult> pair in deliveryResult.GetResults())
        {
            
        }
    }
}
