using Enums;
using Enums.Trigger;

public class DamageOverTimeStatusEffectOld : I_BaseStatusEffectOld
{
    public DamagePackOld DamagePack { get; set; }

    public DamageOverTimeStatusEffectOld(DamagePackOld damagePack) : base()
    {
        DamagePack = damagePack;
    }

    public void Trigger(CharacterTrigger effect, CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper)
    {
        if(effect.TriggerValue.Equals(Character_Trigger_Enum.TURN_START))
        {
            //target.Apply(DamagePack, owner);
        }
    }

    public void Apply(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper)
    {
       // target.StatusEffects[Character_Trigger_Enum.TURN_START].Add(wrapper);
    }

    public void End(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper)
    {
       // target.StatusEffects[Character_Trigger_Enum.TURN_START].Remove(wrapper);
    }

    public void Remove(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper)
    {
        End(target, owner, wrapper);
    }
}
