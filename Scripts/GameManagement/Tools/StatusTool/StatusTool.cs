﻿using DeliverySystem;
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
        public const string TICK_STRING = "TICK";
        public static StatusEnum TICK = new StatusEnum(TICK_STRING, false);

        private List<DerivedStatusEffect>[] statusEvents;

        public DeliveryResultPack currentPack;
 
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
            if (statusEnum.shouldRegister)
            {
                if (!derivedStatusEffect.listsIncluded[statusEnum.intValue])
                {
                    derivedStatusEffect.listsIncluded[statusEnum.intValue] = true;
                    statusEvents[statusEnum.intValue].Add(derivedStatusEffect);
                }
            }
        }

        public void Trigger(StatusEnum statusEnum)
        {
            List<DerivedStatusEffect> statusEffects = statusEvents[statusEnum.intValue];
            bool statusApplied = false;
            currentPack = DeliveryResultPack.GetPack(toolManager);
            for (int x = 0; x < statusEffects.Count; x++)
            {
                DerivedStatusEffect dse = statusEffects[x];
                if (!dse.enabled)
                {
                    dse.listsIncluded[statusEnum.intValue] = false;
                    statusEffects.RemoveAt(x);
                    x--;
                }
                else
                {
                    statusApplied = true;
                    dse.Trigger(statusEnum);
                    currentPack.PublishCurrent();
                }
            }
            if (statusApplied)
            {
                currentPack.Deliver();
            }
            else
            {
                currentPack.Clear();
            }
        }

        public override ToolEnum GetToolEnum()
        {
            return toolEnum;
        }
    }
}
