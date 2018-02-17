namespace Enums.Damage {
    public class DamageType
    {
        public DamageType Parent { get; set; }
        public Damage_Type_Enum DamageValue { get; set; }

        public DamageType(Damage_Type_Enum damage_Enum)
        {
            DamageValue = damage_Enum;
        }

        public DamageType(Damage_Type_Enum damage_Enum, DamageType parent)
        {
            DamageValue = damage_Enum;
            Parent = parent;
        }

        public bool Equals(DamageType damage)
        {
            bool returnValue = damage.DamageValue.Equals(DamageValue);
            if (Parent != null)
            {
                returnValue = returnValue || Parent.Equals(damage);
            }
            return returnValue;
        }
    }
}