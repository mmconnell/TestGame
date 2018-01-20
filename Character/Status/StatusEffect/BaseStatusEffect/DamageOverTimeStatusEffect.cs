using Enums;
using Enums.Trigger;

public class DamageOverTimeStatusEffect : BaseStatusEffect
{
    public DamagePack DamagePack { get; set; }

    public DamageOverTimeStatusEffect(CharacterManager owner, DamagePack damagePack, Persistance persistance, int duration) : base(owner, persistance, duration)
    {
        DamagePack = damagePack;
    }

    public new void Trigger(CharacterTrigger effect, CharacterManager characterManager)
    {
        if(effect.TriggerValue.Equals(Character_Trigger_Enum.TURN_START))
        {
            characterManager.Apply(DamagePack);
        }
        base.Trigger(effect, characterManager);
    }

    public new void Apply(CharacterManager characterManager)
    {
        characterManager.StatusEffects[Character_Trigger_Enum.TURN_START].Add(this);
        base.Apply(characterManager);
    }

    public new void End(CharacterManager characterManager)
    {
        characterManager.StatusEffects[Character_Trigger_Enum.TURN_START].Remove(this);
        base.Apply(characterManager);
    }
}
