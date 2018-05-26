using System;
using System.Collections;
using UnityEngine;

public class TurnTool : MonoBehaviour
{
    private BattleManager currentBattleManager;

    public void Awake()
    {
        InformationManager.RegisterComponent(gameObject, typeof(TurnTool), this);
    }

    public void OnDestroy()
    {
        InformationManager.UnRegisterComponent(gameObject, typeof(TurnTool));
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
        InformationManager.Log("Taking Turn");
        yield return null;
    }
}
