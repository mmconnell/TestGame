using System;
using System.Collections;
using UnityEngine;

namespace Manager
{
    [RequireComponent(typeof(StatusTool))]
    public class TurnManager : AbstractTool
    {
        private BattleManager currentBattleManager;
        private StatusTool statusTool;
        private WaitForSeconds waitForSeconds = new WaitForSeconds(1);

        public static ToolEnum toolEnum;

        public override void Awake()
        {
            base.Awake();
            toolEnum = ToolEnum;
            statusTool = toolManager.Get(StatusTool.toolEnum) as StatusTool;
        }

        public void CalculateInitiative()
        {

        }

        public void SetBattleManager(BattleManager battleManager)
        {
            currentBattleManager = battleManager;
        }

        public BattleManager GetBattleManager()
        {
            return currentBattleManager;
        }

        public bool CanTakeTurn()
        {
            return true;
        }

        public int GetInitiative()
        {
            return UnityEngine.Random.Range(0, 10);
        }

        public IEnumerator TakeTurn()
        {
            statusTool.Trigger(StatusTool.TURN_START);
            statusTool.Trigger(StatusTool.TURN_END);
            EventManager.TriggerEvent(gameObject, "TURN_START");
            EventManager.TriggerEvent(gameObject, "TURN_END");
            yield return waitForSeconds;
        }

        public override ToolEnum GetToolEnum()
        {
            return toolEnum;
        }
    }
}