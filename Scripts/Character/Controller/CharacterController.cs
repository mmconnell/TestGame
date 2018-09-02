using Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    public bool isTurn;

    public virtual void Awake()
    {
        CreatureCreator.CreateCreature(gameObject);
    }

    public abstract IEnumerator TakeTurn();
}
