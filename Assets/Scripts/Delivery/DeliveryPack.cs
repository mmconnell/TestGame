using EnumsNew;
using System.Collections.Generic;
using UnityEngine;

namespace Delivery
{
    public class DeliveryPack
    {
        public List<EffectPack> PrimaryEffects { get; private set; }
        public List<EffectPack> SecondaryEffects { get; private set; }

        public DeliveryPack(List<EffectPack> primaryEffects, List<EffectPack> effects)
        {
            PrimaryEffects = primaryEffects ?? new List<EffectPack>();
            SecondaryEffects = effects ?? new List<EffectPack>();
        }

        public DeliveryPack()
        {
            SecondaryEffects = new List<EffectPack>();
        }

        public void AddPrimaryEffect(EffectPack effectPack)
        {
            if(effectPack != null)
            {
                PrimaryEffects.Add(effectPack);
            }
        }

        public void AddPrimaryEffect(List<EffectPack> effectPacks)
        {
            if(effectPacks != null)
            {
                PrimaryEffects.AddRange(effectPacks);
            }
        }

        public void AddSecondaryEffect(EffectPack effectPack)
        {
            if (effectPack != null)
            {
                SecondaryEffects.Add(effectPack);
            }
        }

        public void AddSecondaryEffect(List<EffectPack> effectPacks)
        {
            if (effectPacks != null)
            {
                SecondaryEffects.AddRange(effectPacks);
            }
        }

        public DeliveryPack CopyDeliveryPack()
        {
            DeliveryPack newDeliveryPack = new DeliveryPack();
            List<EffectPack> effectPack = new List<EffectPack>();
            //List<DamagePack> damagePack = new List<DamagePack>();
            effectPack.AddRange(SecondaryEffects);
            newDeliveryPack.SecondaryEffects = effectPack;
            return newDeliveryPack;
        }

        public void Apply(GameObject owner, GameObject target)
        {
            I_EntityManager entityOwner = InformationManager.GetManager(owner), entityTarget = InformationManager.GetManager(target);
            Apply(entityOwner, entityTarget);
        }

        public void Apply(I_EntityManager owner, I_EntityManager target) {
            //List<Result> results = new List<Result>();
            //Dictionary<Delivery_Pack_Shifts, AttributeShift> shifts = new Dictionary<Delivery_Pack_Shifts, AttributeShift>();
            //Dictionary<Damage_Type_Enum, int> damageDone = new Dictionary<Damage_Type_Enum, int>();
            //DeliveryPack newDeliveryPack = CopyDeliveryPack();
            foreach(EffectPack ep in SecondaryEffects)
            {
                ep.Apply(owner, target);
            }
        }
    }
}