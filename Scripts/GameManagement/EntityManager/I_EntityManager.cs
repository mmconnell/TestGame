using UnityEngine;
using System.Collections;

public interface I_EntityManager
{
    bool CanTakeTurn();
    IEnumerator TakeTurn();
    int GetInitiative();
    void CalculateInitiative();
    bool CanRecieveStatus();
    bool CanRecieveDamage();
    void SetBattleManager(BattleManager bm);
    BattleManager GetBattleManager();
}
