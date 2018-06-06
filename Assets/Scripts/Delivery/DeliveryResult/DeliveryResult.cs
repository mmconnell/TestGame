using EnumsNew;
using Manager;
using System.Collections.Generic;

namespace Delivery
{
    public class DeliveryResult
    {
        public List<DerivedStatusEffect> AppliedStatusEffects { get; private set; }
        public int[] DamageDone { get; private set; }
        public List<bool> DamageUpdated { get; private set; }
        public Dictionary<string, object> ExtraParameters { get; private set; }
        public bool Critical { get; set; }
        public bool empty = true;

        public DeliveryResult()
        {
            AppliedStatusEffects = new List<DerivedStatusEffect>();
            Damage_Type_Enum[] damageTypes = DamageTool.GetDamageTypes();
            DamageDone = new int[damageTypes.Length];
            DamageUpdated = new List<bool>();
            foreach (Damage_Type_Enum damageType in damageTypes)
            {
                DamageUpdated.Add(false);
            }
            ExtraParameters = new Dictionary<string, object>();
            Critical = false;
        }
    }
}
