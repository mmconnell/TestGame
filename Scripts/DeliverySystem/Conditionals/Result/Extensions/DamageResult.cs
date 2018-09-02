using System.Collections.Generic;
using EnumsNew;
using Manager;
using UnityEngine;

namespace DeliverySystem
{
    public class DamageResult : I_Result
    {
        public DamagePack DamagePack {get; set;}

        public DamageResult(DamagePack damagePack) {
            DamagePack = damagePack;
        }

        public void Apply(ToolManager owner, ToolManager target, List<I_Result> results)
        {
            throw new System.NotImplementedException();
        }
    }
}