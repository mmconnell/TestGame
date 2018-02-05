using Enums.Trigger;

public interface I_BaseStatusEffect
{
    void Trigger(CharacterTrigger trigger, CharacterManager target, CharacterManager owner, StatusEffectWrapper wrapper);
    void Apply(CharacterManager target, CharacterManager owner, StatusEffectWrapper wrapper);
    void Remove(CharacterManager target, CharacterManager owner, StatusEffectWrapper wrapper);
    void End(CharacterManager target, CharacterManager owner, StatusEffectWrapper wrapper);
}
