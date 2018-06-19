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
            go.AddComponent<StatusTool>();
            go.AddComponent<TurnManager>();
            go.AddComponent<DamageTool>();
            go.AddComponent<ResistanceTool>();
            go.AddComponent<BuffTool>();
            go.AddComponent<InitiativeTool>();
            go.AddComponent<DeliveryTool>();
            go.AddComponent<AttributeTool>();
        }

        public static void CreateInatimate(GameObject go)
        {

        }

        public static void CreateHuman(GameObject go, string name)
        {
            CreateCreature(go);
            //go.name = name;
        }

        public static void CreateTotem(GameObject go, string name)
        {

        }
    }
}
