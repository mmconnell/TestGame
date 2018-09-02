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
        private CharacterController characterController;

        public static ToolEnum toolEnum;

        public override void Awake()
        {
            base.Awake();
            toolEnum = ToolEnum;
            statusTool = toolManager.Get(StatusTool.toolEnum) as StatusTool;
            characterController = gameObject.GetComponent<CharacterController>();
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
            yield return StartCoroutine(characterController.TakeTurn());
            statusTool.Trigger(StatusTool.TURN_END);
        }

        public override ToolEnum GetToolEnum()
        {
            return toolEnum;
        }
    }
}