using Enums.Trigger;
using System.Collections.Generic;

public class DelayedStatusEffect : I_BaseStatusEffect
{
    public List<EffectPack> StatusEffect { get; set; }
    public List<DamagePack> DamagePack { get; set; }
    public DelayedStatusEffect(List<DamagePack> damagePack, List<EffectPack> statusEffect)
    {
        StatusEffect = statusEffect;
        if(StatusEffect == null)
        {
            StatusEffect = new List<EffectPack>();
        }
        DamagePack = damagePack;
        if(DamagePack == null)
        {
            DamagePack = new List<DamagePack>();
        }
    }

    public void End(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper)
    {
        DeliveryPack dp = new DeliveryPack(owner, DamagePack, StatusEffect);
        target.Apply(dp);
    }

    public void Remove(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper){}

    public void Trigger(CharacterTrigger trigger, CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper){}

    public void Apply(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper){}

    void I_BaseStatusEffect.Remove(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper){}
}