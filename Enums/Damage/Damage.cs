namespace Enums.Damage {
    public class Damage
    {
        private Damage Parent { get; set; }
        public Damage_Enum DamageValue { get; set; }

        public Damage(Damage_Enum damage_Enum)
        {
            DamageValue = damage_Enum;
        }

        public Damage(Damage_Enum damage_Enum, Damage parent)
        {
            DamageValue = damage_Enum;
            Parent = parent;
        }

        public bool Equals(Damage damage)
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