using EnumsNew;
using System.Collections.Generic;

namespace Delivery
{
    public class SubDeliveryResult
    {
        public List<DerivedStatusEffect> AppliedStatusEffects { get; private set; }
        public Dictionary<Damage_Type_Enum, int> DamageDone { get; private set; }
        public Dictionary<string, object> ExtraParameters { get; private set; }
        public bool Critical { get; set; }

        public SubDeliveryResult()
        {
            AppliedStatusEffects = new List<DerivedStatusEffect>();
            DamageDone = new Dictionary<Damage_Type_Enum, int>();
            ExtraParameters = new Dictionary<string, object>();
            Critical = false;
        }
    }
}
