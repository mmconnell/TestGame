using Enums;
using Enums.Trigger;

public interface I_StatusEffectWrapper
{
    void Trigger(CharacterTrigger trigger, CharacterManager status);
    void Apply(CharacterManager target);
    void Remove(CharacterManager target);
    void End(CharacterManager target);
}
