using EnumsNew;
using Manager;
using System.Collections.Generic;

namespace DeliverySystem
{
    public class DeliveryResultPack
    {
        private static int initialTemporarySize = 5;

        private static int initialPacks = 100;
        private static List<DeliveryResultPack> availableDeliveryResultPacks;

        public static DeliveryResultPack GetPack(ToolManager target)
        {
            if (availableDeliveryResultPacks == null)
            {
                availableDeliveryResultPacks = new List<DeliveryResultPack>(initialPacks);
                
                for (int x = 0; x < initialPacks; x++)
                {
                    availableDeliveryResultPacks.Add(new DeliveryResultPack());
                }
            }
            DeliveryResultPack drp;
            if (availableDeliveryResultPacks.Count == 0)
            {
                drp = new DeliveryResultPack();
                drp.Initialize(target);
                return drp;
            }
            drp = availableDeliveryResultPacks[0];
            availableDeliveryResultPacks.RemoveAt(0);
            drp.Initialize(target);
            return drp;
        }

        private DeliveryResult deliveryResult;
        private List<DeliveryResult> temporaryDeliveryResults;
        private int current = 0;

        private ToolManager target;

        public DeliveryResultPack()
        {
            deliveryResult = new DeliveryResult();
            temporaryDeliveryResults = new List<DeliveryResult>(5);
            
            for (int x = 0; x < initialTemporarySize; x++)
            {
                temporaryDeliveryResults.Add(new DeliveryResult());
            }
        }

        public void Initialize(ToolManager target)
        {
            this.target = target;
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

        public void PublishCurrent()
        {
            DamageTool damageable = target.Get(DamageTool.toolEnum) as DamageTool;
            DeliveryResult temporaryDeliveryResult = temporaryDeliveryResults[current];
            DeliveryTool deliveryTool = target.Get(DeliveryTool.toolEnum) as DeliveryTool;
            deliveryTool.ApplyAttackFilters(temporaryDeliveryResult);
            if (!temporaryDeliveryResult.empty)
            {
                if (damageable)
                {
                    for (int x = 0; x < temporaryDeliveryResult.DamageDone.Length; x++)
                    {
                        int damage = temporaryDeliveryResult.DamageDone[x];
                        if (damage != 0)
                        {
                            Damage_Type_Enum damageType = DamageTool.GetDamageType(x);
                            deliveryResult.DamageDone[x] += damageable.GetDamage(damageType, damage);
                            deliveryResult.empty = false;
                            deliveryResult.Owner = temporaryDeliveryResult.Owner;
                        }
                    }
                }
                if (temporaryDeliveryResult.AppliedStatusEffects.Count > 0)
                {
                    deliveryResult.AppliedStatusEffects.AddRange(temporaryDeliveryResult.AppliedStatusEffects);
                    deliveryResult.empty = false;
                }
                temporaryDeliveryResult.Clear();
            }
            current--;
            if (current < 0)
            {
                current = 0;
            }
        }

        public void Deliver()
        {
            int x = 0;
            DeliveryTool dt = target.Get(DeliveryTool.toolEnum) as DeliveryTool;
            DamageTool damageTool = target.Get(DamageTool.toolEnum) as DamageTool;
            dt.ApplyFinalFilters(deliveryResult);
            foreach (int damage in deliveryResult.DamageDone)
            {
                if (damage != 0)
                {
                    Damage_Type_Enum damageType = DamageTool.GetDamageType(x);
                    damageTool.TakeDamageRaw(damageType, damage);
                }
                x++;
            }
            foreach (DerivedStatusEffect dse in deliveryResult.AppliedStatusEffects)
            {
                dse.Enable();
            }
            deliveryResult.Clear();
            availableDeliveryResultPacks.Add(this);
        }

        public void Clear()
        {
            deliveryResult.Clear();
            availableDeliveryResultPacks.Add(this);
        }

        public void PublishAll()
        {
            DeliveryResult dr = GetCurrent();
            while (!dr.empty || current > 0)
            {
                PublishCurrent();
                dr = GetCurrent();
            }
            DeliveryTool dt = target.Get(DeliveryTool.toolEnum) as DeliveryTool;
            Deliver();
        }
    }
}
