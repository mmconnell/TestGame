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

        private List<DeliveryResult> deliveryResults;
        private int current = 0;
        public bool update = false;

        public override void Awake()
        {
            base.Awake();
            toolEnum = ToolEnum;
            deliveryResults = new List<DeliveryResult>();
            for (int x = 0; x < maxDeliveryResults; x++)
            {
                deliveryResults.Add(null);
            } 
        }

        void Update()
        {
            if (update)
            {
                Apply();
                update = false;
            }
        }

        public DeliveryResult GetNext()
        {
            DeliveryResult deliveryResult = null;
            if (current == deliveryResults.Count)
            {
                deliveryResult = deliveryResults[current - 1];
            }
            else
            {
                deliveryResult = deliveryResults[current];
            }
            if (deliveryResult == null)
            {
                deliveryResult = new DeliveryResult();
                deliveryResults[current] = deliveryResult;
            }
            if (current < deliveryResults.Count)
            {
                current++;
            }
            return deliveryResult;
        }

        public DeliveryResult GetCurrent()
        {
            DeliveryResult deliveryResult = null;
            if (current == deliveryResults.Count)
            {
                deliveryResult = deliveryResults[current - 1];
            }
            else
            {
                deliveryResult = deliveryResults[current];
            }
            if (deliveryResult == null)
            {
                deliveryResult = new DeliveryResult();
                deliveryResults[current] = deliveryResult;
            }
            return deliveryResult;
        }

        public void Apply()
        {
            for (int x = 0; x <= current; x++)
            {
                DamageTool damageable = toolManager.Get(DamageTool.toolEnum) as DamageTool;
                DeliveryResult deliveryResult = deliveryResults[x];
                if (damageable)
                {
                    int count = 0;
                    foreach (int damage in deliveryResult.DamageDone)
                    {
                        if (damage != 0)
                        {
                            Damage_Type_Enum damageType = DamageTool.GetDamageType(count);
                            damageable.TakeDamage(damageType, damage);
                        }
                        deliveryResult.DamageDone[count] = 0;
                        count++;
                    }
                }
            }
            current = 0;
        }

        public override ToolEnum GetToolEnum()
        {
            return toolEnum;
        }
    }
}
