using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public List<I_EntityManager> TurnOrder;
    public List<I_EntityManager> NextTurnOrder;
    public List<I_EntityManager> Swap;
    public List<GameObject> Entities;
    public bool Inturruptable { get; private set; }
    public bool requestInturrupt = false;
    public bool endBattle = false;
    public bool merging = false;
    public int count = 0;

    private void Awake()
    {
        Entities = new List<GameObject>();
        TurnOrder = new List<I_EntityManager>();
        NextTurnOrder = new List<I_EntityManager>();
        Inturruptable = false;
    }

    void Start()
    {
        foreach (GameObject go in Entities)
        {
            if (!InformationManager.IsTemporaryTag(go.tag)) 
            {
                I_EntityManager manager = InformationManager.GetManager(go);
                if (manager.CanTakeTurn())
                {
                    manager.CalculateInitiative();
                    AddOrdered(TurnOrder, manager, 0);
                    manager.SetBattleManager(this);
                }
            }
        }
        StartCoroutine(RunBattle());
    }

    public void AddToBattle(GameObject go)
    {
        if (!InformationManager.IsTemporaryTag(go.tag))
        {
            I_EntityManager manager = InformationManager.GetManager(go);
            if(manager != null) {
                BattleManager bm = manager.GetBattleManager();
                if (bm != null)
                {
                    MergeBattles(bm);
                }
                else
                {
                    if (manager.CanTakeTurn())
                    {
                        manager.CalculateInitiative();
                        AddOrdered(TurnOrder, manager, 1);
                        manager.SetBattleManager(this);
                    }
                }
            }
        }
    }

    public void MergeBattles(BattleManager bm)
    {
        StartCoroutine(MergeBattleHelper(bm));
    }

    // public void WaitForMerge(BattleManager bm)
    // {
    //     StartCoroutine(WaitForMergeHelper(bm));
    // }

    // private IEnumerator WaitForMergeHelper(BattleManager bm)
    // {
    //     yield return new WaitUntil(() => !bm.merging);
    // }

    private IEnumerator MergeBattleHelper(BattleManager bm)
    {
        yield return new WaitUntil(() => !merging);
        // if(merging)
        // {
        //     bm.WaitForMerge(this);
        // }
        merging = true;
        bm.merging = true;
        requestInturrupt = true;
        bm.requestInturrupt = true;
        //while(!bm.Inturruptable || !Inturruptable)
        //{
        //    yield return null;
        //}
      yield return (new WaitUntil(() => bm.Inturruptable && Inturruptable));
//      yield return new WaitWhile(() => { return !bm.Inturruptable || !Inturruptable; });
        if(!bm.Inturruptable)
        {
            Debug.Log("bm " + bm.name);
        }
        if(!Inturruptable)
        {
            Debug.Log("this " + name);
        }
        //Debug.Log(bm.Inturruptable && Inturruptable);
        yield return new WaitForSeconds(2);
        MergeInitiative(TurnOrder, bm.TurnOrder);
        MergeInitiative(NextTurnOrder, bm.NextTurnOrder);
        MergeEntities(Entities, bm.Entities);
        bm.TurnOrder.Clear();
        bm.NextTurnOrder.Clear();
        bm.Entities.Clear();
        bm.endBattle = true;
        bm.requestInturrupt = false;
        requestInturrupt = false;
        merging = false;
    }

    private void MergeInitiative(List<I_EntityManager> main, List<I_EntityManager> other)
    {
        I_EntityManager em;
        if(other.Count == 0)
        {
            return;
        }
        for(int x = 0; x < main.Count; x++)
        {
            em = other[0];
            if(em.GetInitiative() > main[x].GetInitiative())
            {
                main.Insert(x, em);
                other.RemoveAt(0);
                if(other.Count == 0)
                {
                    return;
                }
                em = other[0];
            }
        }
        while(other.Count > 0)
        {
            main.Add(other[0]);
            other.RemoveAt(0);
        }
    }

    private void MergeEntities(List<GameObject> main, List<GameObject> other)
    {
        main.InsertRange(0, other);
    }

    private IEnumerator RunBattle()
    {
        yield return null;
        while (!BattleComplete())
        {
            Inturruptable = true;
            yield return CoroutineManager.WaitForSeconds(.1f);
            while(requestInturrupt)
            {
                yield return null;
            }
//            yield return new WaitUntil(() => !requestInturrupt);
            Inturruptable = false;
            if (!endBattle)
            {
                if (TurnOrder.Count < 1)
                {
                    Swap = TurnOrder;
                    TurnOrder = NextTurnOrder;
                    NextTurnOrder = Swap;
                }
                //Debug.Log(gameObject.name + ": " + TurnOrder.Count + " left");
                I_EntityManager entityManager = TurnOrder[0];
                
                TurnOrder.RemoveAt(0);
                int count = TurnOrder.Count;
                yield return StartCoroutine(entityManager.TakeTurn());
                if(TurnOrder.Count != count)
                {
                    Debug.Log(TurnOrder.Count - count);
                }
                entityManager.CalculateInitiative();
                AddOrdered(NextTurnOrder, entityManager, 0);
                yield return null;
            }
        }
        Destroy(gameObject);
    }

    private bool BattleComplete()
    {
        count++;
        return ((false && !requestInturrupt) || (endBattle));
    }

    private bool AddOrdered(List<I_EntityManager> list, I_EntityManager unit, int start)
    {
        for(int x = start; x < list.Count; x++)
        {
            if (unit.GetInitiative() > list[x].GetInitiative())
            {
                list.Insert(x, unit);
                return true;
            }
        }
        list.Add(unit);
        return true;
    }
}
