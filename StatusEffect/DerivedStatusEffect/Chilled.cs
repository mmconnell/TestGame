using UnityEngine;
using System.Collections.Generic;
using Enums.Damage;

public class Chilled : MonoBehaviour
{
    public int? duration;
    public GameObject owner;
    public GameObject target;

    private List<I_BaseStatusEffect> baseStatusEffects;

    void Awake()
    {
        target = transform.parent.gameObject;
        baseStatusEffects = new List<I_BaseStatusEffect>();
        baseStatusEffects.Add(new DamageOverTimeStatusEffect(new FlatDamage(DamageTypes.COLD, 10)));
    }

    void Start()
    {
        foreach(I_BaseStatusEffect bse in baseStatusEffects)
        {
            //bse.Apply(target, owner);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TurnStart()
    {

    }
}
