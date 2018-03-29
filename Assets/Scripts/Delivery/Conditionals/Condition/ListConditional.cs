using System;
using System.Collections.Generic;
using EnumsNew;

namespace Delivery
{
    public class ListConditional : Conditional
    {
        private List<Conditional> conditionals;

        public ListConditional(List<Conditional> conditionals)
        {
            this.conditionals = conditionals;
        }

        public override void Apply(I_EntityManager owner, I_EntityManager target, DeliveryPack pack, List<Result> results, Dictionary<Delivery_Pack_Shifts, AttributeShift> shifts)
        {
            foreach (Conditional conditional in conditionals)
            {
                if (conditional.IsCondition())
                {
                    conditional.Apply(owner, target, pack, results, shifts);
                }
            }
        }

        public override bool IsCondition() {
            return true;
        }
    }
}
