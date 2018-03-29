using EnumsNew;
using System.Collections.Generic;
using UnityEngine;

namespace Delivery
{
    public class DeliveryPack
    {
        public Conditional PreConditions { get; private set; }
        public Conditional PostConditions { get; private set; }
        public List<EffectPack> Effects { get; private set; }
        public List<DamagePack> Damages { get; private set; }

        public DeliveryPack(Conditional preConditions, Conditional postConditions, List<EffectPack> effects, List<DamagePack> damages)
        {
            PreConditions = preConditions;
            PostConditions = postConditions;
            Effects = effects ?? new List<EffectPack>();
            Damages = damages ?? new List<DamagePack>();
        }

        public DeliveryPack()
        {
            Effects = new List<EffectPack>();
            Damages = new List<DamagePack>();
        }

        public void SetPostCondtion(Conditional conditional)
        {
            PostConditions = conditional;
        }

        public void SetPreCondition(Conditional conditionals)
        {
            PreConditions = conditionals;
        }

        public void AddDamage(DamagePack damagePack)
        {
            if (damagePack != null)
            {
                Damages.Add(damagePack);
            }
        }

        public void AddDamage(List<DamagePack> damagePacks)
        {
            if (damagePacks != null)
            {
                Damages.AddRange(damagePacks);
            }
        }

        public void AddEffect(EffectPack effectPack)
        {
            if(effectPack != null)
            {
                Effects.Add(effectPack);
            }
        }

        public void AddEffect(List<EffectPack> effectPacks)
        {
            if(effectPacks != null)
            {
                Effects.AddRange(effectPacks);
            }
        }

        public void Apply(GameObject owner, GameObject target)
        {
            I_EntityManager entityOwner = InformationManager.GetManager(owner), entityTarget = InformationManager.GetManager(target);
            Apply(entityOwner, entityTarget);
        }

        public void Apply(I_EntityManager owner, I_EntityManager target) {
            List<Result> results = new List<Result>();
            Dictionary<Delivery_Pack_Shifts, AttributeShift> shifts = new Dictionary<Delivery_Pack_Shifts, AttributeShift>();
            Dictionary<Damage_Type_Enum, int> damageDone = new Dictionary<Damage_Type_Enum, int>();
            //PreConditions.Apply(entityOwner, entityTarget, this, results, shifts);
            foreach(DamagePack dp in Damages)
            {
                if(!damageDone.ContainsKey(dp.DamageType))
                {
                    damageDone.Add(dp.DamageType, 0);
                }
                damageDone[dp.DamageType] += dp.GetAmount(owner, target);
            }
            foreach(EffectPack ep in Effects)
            {
                ep.Apply(owner, target);
            }
            //PostConditions.Apply(entityOwner, entityTarget, this, results, shifts);
            foreach(Damage_Type_Enum damage in damageDone.Keys)
            {
                ((CharacterManager)target).TakeDamage(damageDone[damage], damage, (CharacterManager)target);
            }
        }
    }
}
