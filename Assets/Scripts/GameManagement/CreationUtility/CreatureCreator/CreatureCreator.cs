using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Manager
{
    public class CreatureCreator
    {
        public static void CreateCreature(GameObject go)
        {
            go.AddComponent<TurnTool>();
            go.AddComponent<Damageable>();
            go.AddComponent<ResistanceTool>();
            go.AddComponent<Buffable>();
            go.AddComponent<TakeTurn>();
            go.AddComponent<Initiative>();
        }

        public static void CreateHuman(GameObject go, string name)
        {
            CreateCreature(go);
            //go.name = name;
        }
    }
}
