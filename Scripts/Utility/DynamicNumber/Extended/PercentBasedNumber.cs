using EnumsNew;
using Manager;
using UnityEngine;

namespace Utility
{
    public class PercentBasedNumber : DynamicNumber
    {
        public PercentOfDamage TypeOfPercent { get; set; }
        private float percent;
        public float Percent { get { return this.percent / 100f; } set { this.percent = value; } }
        public bool SourceIsOwner { get; set; }

        public PercentBasedNumber(PercentOfDamage typeOfPercent, float percent, bool sourceIsOwner)
        {
            TypeOfPercent = typeOfPercent;
            Percent = percent;
            SourceIsOwner = sourceIsOwner;
        }

        public override float GetAmount(ToolManager owner, ToolManager target)
        {
            ToolManager source = SourceIsOwner ? owner : target;
            return  GetAmount(source);
        }

        public override float GetAmount(ToolManager source)
        {
            float health = 0;
            switch (TypeOfPercent)
            {
                case PercentOfDamage.MAX_HEALTH:
                    //health = source.MaxHealth;
                    break;
                case PercentOfDamage.CURRENT_HEALTH:
                    //health = source.Health;
                    break;
                case PercentOfDamage.MISSING_HEALTH:
                    //health = source.MaxHealth - source.Health;
                    break;
            }
            return (health * (Percent));
        }
    }

    public enum PercentOfDamage
    {
        MAX_HEALTH, CURRENT_HEALTH, MISSING_HEALTH
    }
}