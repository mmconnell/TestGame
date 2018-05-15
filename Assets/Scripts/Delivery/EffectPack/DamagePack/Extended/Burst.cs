﻿using EnumsNew;
using UnityEngine;

namespace Delivery
{
    public class Burst : DamagePack
    {
        public DamagePack DamagePack { get; set; }
        public double Radius { get; set; }
        public Team_Target TeamTarget { get; set; }

        public Burst(Damage_Type_Enum damageType, DamagePack damagePack, double radius, Team_Target teamTarget) : base(damageType)
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

        public override int GetAmount(I_EntityManager target, I_EntityManager owner)
        {
            return DamagePack.GetAmount(target, owner);
        }

        public override void Apply(CharacterManager target, CharacterManager owner)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(target.gameObject.transform.position, (float)target.GetRadius(Radius));
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

        public override bool Contains(string type)
        {
            return base.Contains(type) || DamagePack.Contains(type);
        }
    }
}