using UnityEngine;
using System.Collections;
using Delivery;

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
    void Apply(DeliveryPack deliveryPack);
    GameObject GameObject();
}
