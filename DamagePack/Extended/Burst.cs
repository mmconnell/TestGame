using Enums;
using Enums.Damage;
using UnityEngine;

public class Burst : DamagePack
{
    public DamagePack DamagePack { get; set; }
    public double Radius { get; set; }
    public TeamTarget TeamTarget { get; set; }

    public Burst(DamageType damageType, DamagePack damagePack, double radius, TeamTarget teamTarget) : base(damageType)
    {
        if (damagePack.Contains(DamagePackType()))
        {
            throw new System.Exception("Burst cannot be made of a burst");
        }
        DamagePack = damagePack;
        Radius = radius;
        TeamTarget = teamTarget;
    }

    public override string DamagePackType()
    {
        return "Burst";
    }

    public override int GetAmount(CharacterManager target, CharacterManager owner)
    {
        return DamagePack.GetAmount(target, owner);
    }

    public new void Apply(CharacterManager target, CharacterManager owner)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(target.Parent.transform.position, (float)target.GetRadius(Radius));
        foreach (Collider2D col in colliders)
        {
            GameObject go = col.gameObject;
            PoorGuy pg = go.GetComponent<PoorGuy>();

            if (pg != null)
            {
                CharacterManager cm = pg.CharacterManager;
                cm.TakeDamage(GetAmount(cm, target), DamageType, target);
            }
        }
    }

    public new bool Contains(string type)
    {
        return base.Contains(type) || DamagePack.Contains(type);
    }
}
