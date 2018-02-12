using Enums;
using Enums.Trigger;

public class DamageOverTimeStatusEffect2 : I_BaseStatusEffect2
{
    public DamagePack DamagePack { get; set; }
    public DerivedStatusEffect2 DerivedStatusEffect { get; set; }

    public DamageOverTimeStatusEffect2(DerivedStatusEffect2 derivedStatusEffect, DamagePack damagePack) : base()
    {
        DamagePack = damagePack;
        DerivedStatusEffect = derivedStatusEffect;
    }

    public void Apply()
    {
        EventManager.StartListening(DerivedStatusEffect.target, "TURN_START", TurnStart);
    }

    public void Remove()
    {
        EventManager.StopListening(DerivedStatusEffect.target, "TURN_START", TurnStart);
    }

    public void End()
    {
        Remove();
    }

    public void TurnStart()
    {
        CharacterManager characterManager = DerivedStatusEffect.target;
        if(characterManager != null)
        {
            characterManager.Apply(DamagePack, DerivedStatusEffect.owner);
        }
    }
}
