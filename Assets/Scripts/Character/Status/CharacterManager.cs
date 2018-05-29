using System;
using System.Collections;
using System.Collections.Generic;
using EnumsNew;
using Delivery;
using UnityEngine;

public class CharacterManager : MonoBehaviour {
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Level { get; set; }
    private BattleManager bm;

    public MonoBehaviour Parent { get; set; }

    //public Dictionary<Character_Trigger_Enum, List<I_StatusEffectWrapper>> StatusEffects { get; set; }
    public Dictionary<Character_Action_Enum, int> DisableCount { get; set; }
    public Dictionary<Character_Attribute_Enum, List<NumberShift>> CharacterAttributeAlteration { get; set; }
    //public Dictionary<Persistance, List<I_StatusEffectWrapper>> PersistanceTracker { get; set; }
    public Dictionary<Damage_Type_Enum, int> DamageTaken { get; set; }
    //public Dictionary<I_StatusEffectWrapper, HashSet<CharacterManager>> AuraLastEffected { get; set; }
    public Dictionary<Character_Stat, int> CurrentStats { get; set; }
    //public Dictionary<I_StatusEffectWrapper, List<I_StatusEffectWrapper>> Auras { get; set; }

    //public List<DamageType> DamageTypesTaken { get; set; }

    //public HashSet<DerivedStatusEffectOld> BuffAndDebuffList { get; set; }
    public HashSet<DerivedStatusEffect> StatusEffectList { get; set; }
    public Dictionary<string, int> StringStatusEffectList { get; set; }

    public System.Random RandomGenerator { get; set; }

    public void Start()//CharacterManager(MonoBehaviour parent)
    {
        //Parent = parent;
        Health = 997;
        MaxHealth = 997;
        //StatusEffects = new Dictionary<Character_Trigger_Enum, List<I_StatusEffectWrapper>>();
        DisableCount = new Dictionary<Character_Action_Enum, int>();
        CharacterAttributeAlteration = new Dictionary<Character_Attribute_Enum, List<NumberShift>>();
        //PersistanceTracker = new Dictionary<Persistance, List<I_StatusEffectWrapper>>();
        DamageTaken = new Dictionary<Damage_Type_Enum, int>();
        //AuraLastEffected = new Dictionary<I_StatusEffectWrapper, HashSet<CharacterManager>>();
        CurrentStats = new Dictionary<Character_Stat, int>();
        //Auras = new Dictionary<I_StatusEffectWrapper, List<I_StatusEffectWrapper>>();

        //DamageTypesTaken = new List<DamageType>();
        //BuffAndDebuffList = new HashSet<DerivedStatusEffectOld>();
        StatusEffectList = new HashSet<DerivedStatusEffect>();
        StringStatusEffectList = new Dictionary<string, int>();

        RandomGenerator = new System.Random(10);

        foreach (Character_Action_Enum a in Enum.GetValues(typeof(Character_Action_Enum)))
        {
            DisableCount.Add(a, 0);
        }
        foreach (Character_Trigger_Enum se in Enum.GetValues(typeof(Character_Trigger_Enum)))
        {
            //StatusEffects.Add(se, new List<I_StatusEffectWrapper>());
        }
        foreach (Character_Attribute_Enum cae in Enum.GetValues(typeof(Character_Attribute_Enum)))
        {
            CharacterAttributeAlteration.Add(cae, new List<NumberShift>());
        }
        foreach (Persistance p in Enum.GetValues(typeof(Persistance)))
        {
            //PersistanceTracker.Add(p, new List<I_StatusEffectWrapper>());
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

    public void Trigger(Character_Trigger_Enum trigger)
    {
        //List<I_StatusEffectWrapper> sews = new List<I_StatusEffectWrapper>();
        //sews.AddRange(StatusEffects[trigger.TriggerValue]);
        //for(int x = 0; x < sews.Count; x++)
        //{
            //I_StatusEffectWrapper sew = sews[x];
            //sew.Trigger(trigger, this);
        //}
    }

    public void Apply(DeliveryPack deliveryPack, CharacterManager owner)
    {
        //deliveryPack.Apply(owner.gameObject, gameObject);
       /* foreach(DamagePack dpw in deliveryPack.DamagePacks)
        {
            Apply(dpw, owner);
        }
        foreach (EffectPackOld ep in deliveryPack.EffectPacks)
        {
            Apply(ep, owner);
        }*/
    }

    public void Apply(DamagePack damagePack, CharacterManager owner)
    {
        //int damageDone = damagePack.GetAmount(this, owner);
        //....Do stuff
        //Debug.Log(damageDone + "");
        //damagePack.Apply(this, owner);
        //Trigger(DamageTypes.DamageToTriggers[damagePack.DamageType].ReceiveDamage);
        //damagePack.Respond(this, owner, damageDone);
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

    public int GetResistance(Damage_Type_Enum damageType)
    {
        /*CharacterAttribute ca = DamageTypes.DamageToResistances[damageType];
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
        return (int)total;*/
        return 1;
    }

    /*public double GetStatBonus(CharacterStat characterStat)
    {
        return (CurrentStats[characterStat.StatValue] * .05) + 1.0;
    }*/

    public double GetRadius(double radius)
    {
        return radius;
    }

    /*public void Response(CharacterManager characterManager, int damage, DamageType damageType)
    {

    }
    */
    //public void Response(CharacterManager characterManager, StatusEffectWrapper statusEffect)
    //{
    //
    //}

    public void TakeDamage(int damageAmount, Damage_Type_Enum damageType, CharacterManager owner)
    {
        int damage = CalculateResistance(damageAmount, damageType);
        Debug.Log(gameObject.name + " took " + damageType.ToString() + " " + damage);
    }

    public int CalculateResistance(double amount, Damage_Type_Enum damageType)
    {
        //double resistance = GetResistance(damageType.DamageValue);
        double resistance = 0;
        bool negative = resistance < 0;
        resistance = Mathf.Abs((float)resistance);
        resistance /= 100.0;
        if(negative)
        {
            amount *= (resistance + 1.0);
        } else
        {
            resistance = 1 - resistance;
            amount *= resistance;
            // if(resistance < 0) {
            //     resistance = Mathf.Abs((float)resistance);
            //     amount *= resistance;
            // } else 
            // {
            //     amount *= resistance;
            // }
        }
        return (int)amount;
    }

    public bool CanTakeTurn()
    {
        return true;
    }

    public bool CanRecieveStatus()
    {
        return true;
    }

    public bool CanRecieveDamage()
    {
        return true;
    }

    public IEnumerator TakeTurn()
    {
        yield return new WaitForSeconds(.1f);
    }

    public int GetInitiative()
    {
        return RandomGenerator.Next();
    }

    public void CalculateInitiative()
    {
        
    }

    public void SetBattleManager(BattleManager bm)
    {
        this.bm = bm;
    }

    public BattleManager GetBattleManager()
    {
        return bm;
    }

    public void Apply(DeliveryPack deliveryPack) {

    }

    public GameObject GameObject() {
        return gameObject;
    }
}