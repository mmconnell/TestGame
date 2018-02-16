using System.Collections.Generic;
using UnityEngine;

public abstract class DerivedStatusEffect : MonoBehaviour
{
    protected List<I_BaseStatusEffect> BaseStatusEffects { get; set; }

    public int? duration;
    public CharacterManager owner;
    public CharacterManager target;

    public virtual void Awake()
    {
        target = gameObject.GetComponent<CharacterManager>();
        BaseStatusEffects = new List<I_BaseStatusEffect>();
    }

    public virtual void Start()
    {
        // bool applied = target.StringStatusEffectList.ContainsKey(GetName()) && target.StringStatusEffectList[GetName()] > 0;
        // if (canStack || !applied)
        // {
        //    if(!applied)
        //     {
        //        target.StringStatusEffectList.Add(GetName(), 0);
        //     }
        //    target.StringStatusEffectList[GetName()]++;
        //    target.StatusEffectList.Add(this);
            if (duration != null)
            {
                EventManager.StartListening(gameObject, "TURN_END", TurnEnd);
            }
            foreach (I_BaseStatusEffect bse in BaseStatusEffects)
            {
                bse.Apply();
            }
        // }
    }

    public void AddBaseStatusEffect(I_BaseStatusEffect baseStatusEffect)
    {
        BaseStatusEffects.Add(baseStatusEffect);
    }

    protected void TurnEnd()
    {
        duration -= 1;
        if (duration == 0)
        {
            Destroy(this);
        }
    }

    public virtual void OnDisable()
    {
    //    target.StringStatusEffectList[GetName()]--;
    //    target.StatusEffectList.Remove(this);
        foreach(I_BaseStatusEffect bse in BaseStatusEffects)
        {
            bse.End();
        }
    }

    public void Remove()
    {
        foreach (I_BaseStatusEffect bse in BaseStatusEffects)
        {
            bse.Remove();
        }
        BaseStatusEffects.Clear();
        Destroy(this);
    }

    public virtual string GetName()
    {
        return GetType().Name;
    }
    /*
    public override bool Equals(object other)
    {
        if (other is DerivedStatusEffect2)
        {
            DerivedStatusEffect2 d2 = (DerivedStatusEffect2)other;
            return d2.GetName().Equals(GetName());
        }
        else
        {
            return base.Equals(other);
        }
    }*/
}