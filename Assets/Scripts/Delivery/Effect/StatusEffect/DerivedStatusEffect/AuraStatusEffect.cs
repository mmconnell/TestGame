using UnityEngine;
using System;

public class AuraStatusEffect : DerivedStatusEffect
{
    public Type auraEffect;
    public int radius;
    private GameObject auraCollider;

    public override void Start()
    {
        Debug.Log(GetName());
        if(auraEffect == null || !auraEffect.IsSubclassOf(typeof(DerivedStatusEffect)))
        {
            Debug.LogError("AuraEffect in AuraStatusEffect2 Must be a subclass type of 'DerivedStatusEffect2'");
        }
        auraCollider = new GameObject();
        auraCollider.transform.parent = gameObject.transform;
        auraCollider.name = auraEffect.Name + " Aura";
        CircleCollider2D collider = auraCollider.AddComponent<CircleCollider2D>();
        AuraColliderChecker checker = auraCollider.AddComponent<AuraColliderChecker>();
        checker.AuraEffect = auraEffect;
        collider.radius = radius;
        base.Start();
    }

    public override void OnDisable()
    {
        foreach (I_BaseStatusEffect bse in BaseStatusEffects)
        {
            bse.End();
        }
    }

    public override string GetName()
    {
        return base.GetName() + auraEffect.Name;
    }
}
