using Enums.Trigger;

public interface I_BaseStatusEffectOld
{
    void Trigger(CharacterTrigger trigger, CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper);
    void Apply(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper);
    void Remove(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper);
    void End(CharacterManager target, CharacterManager owner, I_StatusEffectWrapper wrapper);
}
