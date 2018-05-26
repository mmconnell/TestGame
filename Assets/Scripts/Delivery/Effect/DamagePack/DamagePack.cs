using EnumsNew;
using UnityEngine;

namespace Delivery
{
    public abstract class DamagePack : I_Effect
    {
        public Damage_Type_Enum DamageType { get; set; }

        public DamagePack(Damage_Type_Enum damageType)
        {
            DamageType = damageType;
        }

        public abstract int GetAmount(GameObject owner, GameObject target);

        public abstract string DamagePackType();

        public virtual bool Contains(string type)
        {
            return type.Equals(DamagePackType());
        }

        public void Apply(GameObject owner, GameObject target, DeliveryResult deliveryResult)
        {
            int total = GetAmount(owner, target);
            if (deliveryResult.Get(target).DamageDone.ContainsKey(DamageType))
            {
                deliveryResult.Get(target).DamageDone[DamageType] += total;
            } else
            {
                deliveryResult.Get(target).DamageDone.Add(DamageType, total);
            }
        }
    }
}