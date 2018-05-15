using EnumsNew;
using System.Collections.Generic;

namespace Delivery
{
    public abstract class Conditional
    {
        public abstract void Apply(I_EntityManager owner, I_EntityManager target, DeliveryPack pack, DeliveryPack newPack, List<Result> results, Dictionary<Delivery_Pack_Shifts, AttributeShift> shifts);
        public abstract bool IsCondition();
    }
}

