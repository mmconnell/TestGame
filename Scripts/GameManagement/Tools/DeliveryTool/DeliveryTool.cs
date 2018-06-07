using Delivery;
using EnumsNew;
using System.Collections.Generic;

namespace Manager
{
    
    public class DeliveryTool : AbstractTool
    {
        public static ToolEnum toolEnum;
        public static int maxDeliveryResults = 5;

        private DeliveryResult deliveryResult;
        private List<DeliveryResult> temporaryDeliveryResults;
        private int current = 0;

        public List<I_Filter> FinalFilters { get; private set; }
        public List<I_Filter> AttackFilters { get; private set; }

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
            FinalFilters = new List<I_Filter>();
            AttackFilters = new List<I_Filter>();
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
            DamageTool damageable = toolManager.Get(DamageTool.toolEnum) as DamageTool;
            DeliveryResult temporaryDeliveryResult = temporaryDeliveryResults[current];
            ApplyAttackFilters();
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
                        deliveryResult.Owner = temporaryDeliveryResult.Owner;
                    }
                }
                temporaryDeliveryResult.Clear();
            }
            current--;
            if (current < 0)
            {
                current = 0;
            }
        }

        private void ApplyAttackFilters()
        {
            DeliveryResult dr = temporaryDeliveryResults[current];
            foreach (I_Filter filter in AttackFilters)
            {
                filter.Apply(dr.Owner, toolManager, dr);
            }
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

        public void Deliver()
        {
            int x = 0;
            DamageTool damageTool = toolManager.Get(DamageTool.toolEnum) as DamageTool;
            ApplyFinalFilters();
            foreach (int damage in deliveryResult.DamageDone)
            {
                if (damage != 0)
                {
                    Damage_Type_Enum damageType = DamageTool.GetDamageType(x);
                    damageTool.TakeDamageRaw(damageType, damage);
                }
                x++;
            }
            deliveryResult.Clear();
        }

        private void ApplyFinalFilters()
        {
            foreach (I_Filter filter in FinalFilters)
            {
                filter.Apply(deliveryResult.Owner, toolManager, deliveryResult);
            }
        }

        public override ToolEnum GetToolEnum()
        {
            return toolEnum;
        }
    }
}
