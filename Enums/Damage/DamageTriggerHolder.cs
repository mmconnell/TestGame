using UnityEngine;
using System.Collections;
using Enums.Trigger;

public class DamageTriggerHolder
{
    public CharacterTrigger ReceiveDamage { get; set; }
    public CharacterTrigger DealDamage { get; set; }

    public DamageTriggerHolder(CharacterTrigger dealDamage, CharacterTrigger receiveDamage)
    {
        DealDamage = dealDamage;
        ReceiveDamage = receiveDamage;
    }
}
