using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager
{
    public class StatusTool : AbstractTool
    {
        public static ToolEnum toolEnum;

        public const string TURN_START_STRING = "TURN_START";
        public static StatusEnum TURN_START = new StatusEnum(TURN_START_STRING);
        public const string TURN_END_STRING = "TURN_END";
        public static StatusEnum TURN_END = new StatusEnum(TURN_END_STRING);

        private List<DerivedStatusEffect>[] statusEvents; 
 
        public override void Awake()
        {
            base.Awake();
            toolEnum = ToolEnum;
            statusEvents = new List<DerivedStatusEffect>[StatusEnum.current];
            for (int x = 0; x < StatusEnum.current; x++)
            {
                statusEvents[x] = new List<DerivedStatusEffect>();
            }
        }

        public void RegisterStatusEffect(StatusEnum statusEnum, DerivedStatusEffect derivedStatusEffect)
        {
            if (!derivedStatusEffect.listsIncluded[statusEnum.intValue])
            {
                derivedStatusEffect.listsIncluded[statusEnum.intValue] = true;
                statusEvents[statusEnum.intValue].Add(derivedStatusEffect);
            }
        }

        public void Trigger(StatusEnum statusEnum)
        {
            List<DerivedStatusEffect> statusEffects = statusEvents[statusEnum.intValue];
            bool statusApplied = false;
            for (int x = 0; x < statusEffects.Count; x++)
            {
                DerivedStatusEffect dse = statusEffects[x];
                if (dse.ended)
                {
                    dse.listsIncluded[statusEnum.intValue] = false;
                    statusEffects.RemoveAt(x);
                    x--;
                }
                else
                {
                    statusApplied = true;
                    dse.Trigger(statusEnum);
                }
            }
            if (statusApplied)
            {
                DeliveryTool dt = toolManager.Get(DeliveryTool.toolEnum) as DeliveryTool;
                if (dt)
                {
                    dt.PublishAll();
                }
            }
        }

        public override ToolEnum GetToolEnum()
        {
            return toolEnum;
        }
    }
}
