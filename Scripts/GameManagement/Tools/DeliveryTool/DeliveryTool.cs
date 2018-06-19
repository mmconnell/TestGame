using Delivery;
using System.Collections.Generic;

namespace Manager
{
    
    public class DeliveryTool : AbstractTool
    {
        public static ToolEnum toolEnum;
        public static int maxDeliveryResults = 5;

        public List<I_Filter> FinalFilters { get; private set; }
        public List<I_Filter> AttackFilters { get; private set; }

        public HashSet<DeliveryTool> ToDeliver;

        public override void Awake()
        {
            base.Awake();
            toolEnum = ToolEnum;
            ToDeliver = new HashSet<DeliveryTool>();
            FinalFilters = new List<I_Filter>();
            AttackFilters = new List<I_Filter>();
        }

        public void ApplyAttackFilters(DeliveryResult dr)
        {
            foreach (I_Filter filter in AttackFilters)
            {
                filter.Apply(dr.Owner, toolManager, dr);
            }
        }

        public void ApplyFinalFilters(DeliveryResult deliveryResult)
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
