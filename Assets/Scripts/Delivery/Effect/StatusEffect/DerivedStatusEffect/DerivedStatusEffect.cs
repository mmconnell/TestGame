using Manager;
using System.Collections.Generic;
using UnityEngine;

public abstract class DerivedStatusEffect
{
    private List<I_BaseStatusEffect> baseStatusEffects;
    private int duration = -1;
    public ToolManager owner;
    public ToolManager target;
    public StatusTool statusTool;
    private List<I_BaseStatusEffect>[] baseTriggers;
    public bool ended = false;
    public bool[] listsIncluded = new bool[StatusEnum.current];

    protected DerivedStatusEffect(){}

    public DerivedStatusEffect(ToolManager owner, ToolManager target, int duration)
    {
        this.owner = owner;
        this.target = target;
        this.duration = duration;
        statusTool = target.Get(StatusTool.toolEnum) as StatusTool;
        baseStatusEffects = new List<I_BaseStatusEffect>();
        baseTriggers = new List<I_BaseStatusEffect>[StatusEnum.current];
        for (int x = 0; x < baseTriggers.Length; x++)
        {
            baseTriggers[x] = new List<I_BaseStatusEffect>();
        }
    }

    public void Initiate()
    {}

    public virtual void Enable()
    {
        bool[] toAddTo = new bool[StatusEnum.current];
        if (duration != -1 && !listsIncluded[StatusTool.TURN_END.intValue])
        {
            statusTool.RegisterStatusEffect(StatusTool.TURN_END, this);
            toAddTo[StatusTool.TURN_END.intValue] = true;
        }
        foreach (I_BaseStatusEffect bse in baseStatusEffects)
        {
            bse.Apply(this);
            foreach (StatusEnum statusEnum in bse.GetStatusEnums())
            {
                if (!toAddTo[statusEnum.intValue])
                {
                    toAddTo[statusEnum.intValue] = true;
                    statusTool.RegisterStatusEffect(statusEnum, this);
                }
            }
        }
        ended = false;
    }

    public virtual void Disable()
    {
        if (baseStatusEffects != null)
        {
            foreach (I_BaseStatusEffect bse in baseStatusEffects)
            {
                bse.End(this);
            }
            ended = true;
        }
    }

    public void Trigger(StatusEnum statusEnum)
    {
        Trigger(baseTriggers[statusEnum.intValue], statusEnum);
        switch (statusEnum.value)
        {
            case StatusTool.TURN_END_STRING: TurnEnd();
                break;
        }
    }

    private void TurnEnd()
    {
        if (duration > 0)
        {
            duration -= 1;
            if (duration == 0)
            {
                Disable();
            }
        }
    }

    private void Trigger(List<I_BaseStatusEffect> list, StatusEnum statusEnum)
    {
        foreach (I_BaseStatusEffect statusEffect in list)
        {
            statusEffect.Trigger(this, statusEnum);
        }
    }

    public void AddBaseStatusEffect(I_BaseStatusEffect baseStatusEffect)
    {
        StatusEnum[] statusEnums = baseStatusEffect.GetStatusEnums();
        foreach (StatusEnum statusEnum in statusEnums)
        {
            List<I_BaseStatusEffect> list = baseTriggers[statusEnum.intValue];
            list.Add(baseStatusEffect);
        }
        baseStatusEffects.Add(baseStatusEffect);
    }

    public virtual void Remove()
    {
        foreach (I_BaseStatusEffect bse in baseStatusEffects)
        {
            bse.Remove(this);
        }
        ended = true;
    }

    public virtual string GetName()
    {
        return GetType().Name;
    }

    public abstract DerivedStatusEffect Clone(ToolManager owner, ToolManager target, int duration);
}