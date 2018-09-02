using DeliverySystem;
using Manager;
using System.Collections.Generic;

namespace DeliverySystem
{
    public abstract class DerivedStatusEffect : I_DerivedStatus
    {
        private List<I_BaseStatusEffect> baseStatusEffects;
        public I_Ticker Ticker { get; set; }
        public ToolManager owner;
        public ToolManager target;
        public StatusTool statusTool;
        private List<I_BaseStatusEffect>[] baseTriggers;
        public bool enabled = false;
        public bool[] listsIncluded = new bool[StatusEnum.current];

        protected DerivedStatusEffect() { }

        public DerivedStatusEffect(ToolManager owner, ToolManager target)
        {
            this.owner = owner;
            this.target = target;
            statusTool = target.Get(StatusTool.toolEnum) as StatusTool;
            baseStatusEffects = new List<I_BaseStatusEffect>();
            baseTriggers = new List<I_BaseStatusEffect>[StatusEnum.current];
            for (int x = 0; x < baseTriggers.Length; x++)
            {
                baseTriggers[x] = new List<I_BaseStatusEffect>();
            }
        }

        public virtual void Enable()
        {
            if (!enabled)
            {
                bool[] toAddTo = new bool[StatusEnum.current];
                if (Ticker != null)
                {
                    StatusEnum[] statusEnums = Ticker.GetStatusEnums();
                    foreach (StatusEnum statusEnum in statusEnums)
                    {
                        if (!toAddTo[statusEnum.intValue] && !listsIncluded[statusEnum.intValue])
                        {
                            toAddTo[statusEnum.intValue] = true;
                            statusTool.RegisterStatusEffect(statusEnum, this);
                        }
                    }
                }
                foreach (I_BaseStatusEffect bse in baseStatusEffects)
                {
                    bse.Apply(this);
                    foreach (StatusEnum statusEnum in bse.GetStatusEnums())
                    {
                        if (!toAddTo[statusEnum.intValue] && !listsIncluded[statusEnum.intValue])
                        {
                            toAddTo[statusEnum.intValue] = true;
                            statusTool.RegisterStatusEffect(statusEnum, this);
                        }
                    }
                }
                enabled = true;
            }
            if (Ticker != null)
            {
                Ticker.Enable();
            }
        }

        public virtual void Disable()
        {
            if (enabled)
            {
                if (baseStatusEffects != null)
                {
                    foreach (I_BaseStatusEffect bse in baseStatusEffects)
                    {
                        bse.End(this);
                    }
                }
                enabled = false;
            }
            if (Ticker != null)
            {
                Ticker.Disable();
            }
        }

        public virtual void Trigger(StatusEnum statusEnum)
        {
            Trigger(baseTriggers[statusEnum.intValue], statusEnum);
            if (Ticker != null)
            {
                Ticker.Trigger(statusEnum);
            }
        }

        public virtual void Remove()
        {
            foreach (I_BaseStatusEffect bse in baseStatusEffects)
            {
                bse.Remove(this);
            }
            enabled = true;
        }

        public virtual ToolManager Owner()
        {
            return owner;
        }

        public virtual ToolManager Target()
        {
            return target;
        }

        private void Trigger(List<I_BaseStatusEffect> list, StatusEnum statusEnum)
        {
            foreach (I_BaseStatusEffect statusEffect in list)
            {
                statusEffect.Trigger(this, statusEnum);
            }
        }

        protected void AddBaseStatusEffect(I_BaseStatusEffect baseStatusEffect)
        {
            StatusEnum[] statusEnums = baseStatusEffect.GetStatusEnums();
            foreach (StatusEnum statusEnum in statusEnums)
            {
                List<I_BaseStatusEffect> list = baseTriggers[statusEnum.intValue];
                list.Add(baseStatusEffect);
            }
            baseStatusEffects.Add(baseStatusEffect);
        }

        public virtual string GetName()
        {
            return GetType().Name;
        }

        public void SetTicker(I_Ticker ticker)
        {
            Ticker = ticker;
        }

        public abstract I_DerivedStatus Clone(ToolManager owner, ToolManager target);
    }
}