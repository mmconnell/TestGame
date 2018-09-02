using DeliverySystem;
using EnumsNew;
using Manager;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    private static DeliveryManager deliveryManager;
    private static bool endGame = false;

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

    public static void Run(ToolManager owner, I_Position position, I_DeliveryPack deliveryPack)
    {
        if (endGame)
        {
            return;
        }
        Instance.RunMethod(owner, position, deliveryPack);
    }

    protected virtual void RunMethod(ToolManager owner, I_Position position, I_DeliveryPack deliveryPack)
    {
        //DeliveryResult deliveryResult = new DeliveryResult();
        //deliveryPack.Apply(owner, position);
        //ApplyResultMethod(deliveryResult);
    }

    //public static void ApplyResult(DeliveryResult deliveryResult)
    //{
    //    if (endGame)
    //    {
    //        return;
    //    }
   //     Instance.ApplyResultMethod(deliveryResult);
    //}

   // protected virtual void ApplyResultMethod(DeliveryResult deliveryResult)
    //{
    //    foreach (KeyValuePair<ToolManager, SubDeliveryResult> pair in deliveryResult.GetResults())
     //   {
    //        Damageable damageable = pair.Key.Get(Damageable.toolEnum) as Damageable;
    //        if (damageable)
     //       {
    //            foreach (KeyValuePair<Damage_Type_Enum, int> damage in pair.Value.DamageDone)
    //            {
    //                damageable.TakeDamage(damage.Key, damage.Value);
    //            }
    //        }
    //    }
   // }

    public void OnDestroy()
    {
        endGame = true;
    }
}
