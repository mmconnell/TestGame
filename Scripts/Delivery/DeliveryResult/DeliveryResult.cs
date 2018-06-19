using EnumsNew;
using Manager;
using System.Collections.Generic;

namespace Delivery
{
    public class DeliveryResult
    {
        public List<I_DerivedStatus> AppliedStatusEffects { get; private set; }
        public int[] DamageDone { get; private set; }
        public Dictionary<string, object> ExtraParameters { get; private set; }
        public bool Critical { get; set; }
        public ToolManager Owner { get; set; }
        public bool empty = true;

        public DeliveryResult()
        {
            AppliedStatusEffects = new List<I_DerivedStatus>();
            Damage_Type_Enum[] damageTypes = DamageTool.GetDamageTypes();
            DamageDone = new int[damageTypes.Length];
            ExtraParameters = new Dictionary<string, object>();
            Critical = false;
        }

        public void Clear()
        {
            AppliedStatusEffects.Clear();
            for (int x = 0; x < DamageDone.Length; x++)
            {
                DamageDone[x] = 0;
            }
            ExtraParameters.Clear();
            Critical = false;
            Owner = null;
            empty = true;
        }
    }
}
