using System;
using System.Collections.Generic;
using Enums;
using Enums.CharacterStat;
using Enums.CharacterStatus;
using Enums.Damage;
using Enums.Trigger;
using UnityEngine;

public class CharacterManager {
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Level { get; set; }

    public MonoBehaviour Parent { get; set; }

    public Dictionary<Character_Trigger_Enum, List<I_StatusEffectWrapper>> StatusEffects { get; set; }
    public Dictionary<Character_Action_Enum, int> DisableCount { get; set; }
    public Dictionary<Character_Attribute_Enum, List<AttributeShift>> CharacterAttributeAlteration { get; set; }
    public Dictionary<Persistance, List<I_StatusEffectWrapper>> PersistanceTracker { get; set; }
    public Dictionary<Damage_Type_Enum, int> DamageTaken { get; set; }
    public Dictionary<I_StatusEffectWrapper, HashSet<CharacterManager>> AuraLastEffected { get; set; }
    public Dictionary<Character_Stat, int> CurrentStats { get; set; }
    public Dictionary<I_StatusEffectWrapper, List<I_StatusEffectWrapper>> Auras { get; set; }

    public List<DamageType> DamageTypesTaken { get; set; }

    public List<DerivedStatusEffect> BuffAndDebuffList { get; set; }

    public System.Random RandomGenerator { get; set; }

    public CharacterManager(MonoBehaviour parent)
    {
        Parent = parent;
        Health = 997;
        MaxHealth = 997;
        StatusEffects = new Dictionary<Character_Trigger_Enum, List<I_StatusEffectWrapper>>();
        DisableCount = new Dictionary<Character_Action_Enum, int>();
        CharacterAttributeAlteration = new Dictionary<Character_Attribute_Enum, List<AttributeShift>>();
        PersistanceTracker = new Dictionary<Persistance, List<I_StatusEffectWrapper>>();
        DamageTaken = new Dictionary<Damage_Type_Enum, int>();
        AuraLastEffected = new Dictionary<I_StatusEffectWrapper, HashSet<CharacterManager>>();
        CurrentStats = new Dictionary<Character_Stat, int>();
        Auras = new Dictionary<I_StatusEffectWrapper, List<I_StatusEffectWrapper>>();

        DamageTypesTaken = new List<DamageType>();
        BuffAndDebuffList = new List<DerivedStatusEffect>();

        RandomGenerator = new System.Random();

        foreach (Character_Action_Enum a in Enum.GetValues(typeof(Character_Action_Enum)))
        {
            DisableCount.Add(a, 0);
        }
        foreach (Character_Trigger_Enum se in Enum.GetValues(typeof(Character_Trigger_Enum)))
        {
            StatusEffects.Add(se, new List<I_StatusEffectWrapper>());
        }
        foreach (Character_Attribute_Enum cae in Enum.GetValues(typeof(Character_Attribute_Enum)))
        {
            CharacterAttributeAlteration.Add(cae, new List<AttributeShift>());
        }
        foreach (Persistance p in Enum.GetValues(typeof(Persistance)))
        {
            PersistanceTracker.Add(p, new List<I_StatusEffectWrapper>());
        }
        foreach (Damage_Type_Enum dte in Enum.GetValues(typeof(Damage_Type_Enum)))
        {
            DamageTaken.Add(dte, 0);
        }
        foreach(Character_Stat cs in Enum.GetValues(typeof(Character_Stat)))
        {
            CurrentStats[cs] = 1;
        }

        Level = 1;
    }

    public void Trigger(CharacterTrigger trigger)
    {
        List<I_StatusEffectWrapper> sews = new List<I_StatusEffectWrapper>();
        sews.AddRange(StatusEffects[trigger.TriggerValue]);
        for(int x = 0; x < sews.Count; x++)
        {
            I_StatusEffectWrapper sew = sews[x];
            sew.Trigger(trigger, this);
        }
    }

    public void Apply(DeliveryPack deliveryPack)
    {
        foreach(DamagePack dpw in deliveryPack.DamagePacks)
        {
            Apply(dpw, deliveryPack.Owner);
        }
        foreach (EffectPack ep in deliveryPack.EffectPacks)
        {
            Apply(ep, deliveryPack.Owner);
        }
    }

    public void Apply(DamagePack damagePack, CharacterManager owner)
    {
        int damageDone = damagePack.GetAmount(this, owner);
        //....Do stuff
        //Debug.Log(damageDone + "");
        damagePack.Apply(this, owner);
        Trigger(DamageTypes.DamageToTriggers[damagePack.DamageType.DamageValue].ReceiveDamage);
        damagePack.Respond(this, owner, damageDone);
    }

    public void Apply(List<DamagePack> damagePacks)
    {
        
        /*foreach(DamagePack dp in damagePacks)
        {
            DamageType damageType = dp.Damage;
            int damageDealt = CalculateDamage(dp);
            if (damageDealt > 0)
            {
                do
                {
                    if (!DamageTypesTaken.Contains(damageType))
                    {
                        DamageTypesTaken.Add(damageType);
                    }
                    DamageTaken[damageType.DamageValue] += damageDealt;
                } while (damageType != null);
            } else if (damageDealt < 0)
            {
                DamageTypesTaken.Add(DamageTypes.HEALING);
                DamageTaken[DamageTypes.HEALING.DamageValue] += damageDealt;
            }
        }
        foreach(DamageType de in DamageTypesTaken)
        {
            TakeDamage(DamageTaken[de.DamageValue], de);
            Trigger(DamageTypes.DamageToTriggers[de].ReceiveDamage);
            DamageTaken[de.DamageValue] = 0;
        }
        DamageTypesTaken.Clear();*/
    }

    public void Apply(EffectPack effectPack, CharacterManager owner)
    {
        bool success = true;
        if(effectPack.ChanceToSucceed < 100)
        {
            int number = RandomGenerator.Next(1, 100);
            success = number < effectPack.ChanceToSucceed;
        }
        if(success)
        {
            if (effectPack.BaseStatusEffect != null)
            {
                new StatusEffectWrapper(effectPack.BaseStatusEffect, owner, effectPack.Persistance, effectPack.Duration).Apply(this);
            }
            else
            {
                effectPack.StatusEffect.Apply(this, owner, effectPack.Persistance, effectPack.Duration);
            }
        }
    }

    public int GetResistance(Damage_Type_Enum damageType)
    {
        CharacterAttribute ca = DamageTypes.DamageToResistances[damageType];
        if(ca == null)
        {
            return 0;
        }
        double total = 0;
        foreach(AttributeShift shift in CharacterAttributeAlteration[ca.CharacterAttributeValue])
        {
            total += shift.Multiplier;
            total -= shift.Devisor;
        }
        return (int)total;
    }

    public double GetStatBonus(CharacterStat characterStat)
    {
        return (CurrentStats[characterStat.StatValue] * .05) + 1.0;
    }

    public double GetRadius(double radius)
    {
        return radius;
    }

    public void Response(CharacterManager characterManager, int damage, DamageType damageType)
    {

    }

    public void Response(CharacterManager characterManager, StatusEffectWrapper statusEffect)
    {

    }

    public void TakeDamage(int damageAmount, DamageType damageType, CharacterManager owner)
    {
        int damage = CalculateResistance(damageAmount, damageType);
        Debug.Log(damage);
    }

    public int CalculateResistance(double amount, DamageType damageType)
    {
        double resistance = GetResistance(damageType.DamageValue);
        resistance /= 100.0;
        resistance = 1.0 + resistance;
        amount /= resistance;
        return (int)amount;
    }
}