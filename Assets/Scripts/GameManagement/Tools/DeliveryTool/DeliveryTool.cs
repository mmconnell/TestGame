using Delivery;
using EnumsNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager
{
    
    public class DeliveryTool : AbstractTool
    {
        public static ToolEnum toolEnum;
        public static int maxDeliveryResults = 5;

        private DeliveryResult deliveryResult;
        private List<DeliveryResult> temporaryDeliveryResults;
        private int current = 0;
        public HashSet<DeliveryTool> ToDeliver;

        public override void Awake()
        {
            base.Awake();
            toolEnum = ToolEnum;
            deliveryResult = new DeliveryResult();
            temporaryDeliveryResults = new List<DeliveryResult>();
            ToDeliver = new HashSet<DeliveryTool>();
            for (int x = 0; x < maxDeliveryResults; x++)
            {
                temporaryDeliveryResults.Add(new DeliveryResult());
            } 
        }

        public void SetNext()
        {
            current++;
            if (current == temporaryDeliveryResults.Count)
            {
                temporaryDeliveryResults.Add(new DeliveryResult());
            }
        }

        public DeliveryResult GetCurrent()
        {
            DeliveryResult deliveryResult = null;
            if (current == temporaryDeliveryResults.Count)
            {
                deliveryResult = temporaryDeliveryResults[current - 1];
            }
            else
            {
                deliveryResult = temporaryDeliveryResults[current];
            }
            if (deliveryResult == null)
            {
                deliveryResult = new DeliveryResult();
                temporaryDeliveryResults[current] = deliveryResult;
            }
            return deliveryResult;
        }

        public bool PublishCurrent()
        {
            DamageTool damageable = toolManager.Get(DamageTool.toolEnum) as DamageTool;
            DeliveryResult temporaryDeliveryResult = temporaryDeliveryResults[current];
            if (damageable && !temporaryDeliveryResult.empty)
            {
                for (int x = 0; x < temporaryDeliveryResult.DamageDone.Length; x++)
                {
                    int damage = temporaryDeliveryResult.DamageDone[x];
                    if (damage != 0)
                    {
                        Damage_Type_Enum damageType = DamageTool.GetDamageType(x);
                        deliveryResult.DamageDone[x] += damageable.GetDamage(damageType, damage);
                        deliveryResult.empty = false;
                    }
                    temporaryDeliveryResult.DamageDone[x] = 0;
                }
                temporaryDeliveryResult.empty = true;
            }
            current--;
            if (current < 0)
            {
                current = 0;
                return true;
            }
            return false;
        }

        public void PublishAll()
        {
            DeliveryResult dr = GetCurrent();
            while (!dr.empty || current > 0)
            {
                PublishCurrent();
            }
            Deliver();
        }

        public bool Deliver()
        {
            int x = 0;
            DamageTool damageTool = toolManager.Get(DamageTool.toolEnum) as DamageTool;
            foreach (int damage in deliveryResult.DamageDone)
            {
                if (damage != 0)
                {
                    Damage_Type_Enum damageType = DamageTool.GetDamageType(x);
                    damageTool.TakeDamageRaw(damageType, damage);
                }
                deliveryResult.DamageDone[x] = 0;
                x++;
            }
            deliveryResult.empty = true;
            return true;
        }

        public override ToolEnum GetToolEnum()
        {
            return toolEnum;
        }
    }
}
