using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class BattleManager : MonoBehaviour
    {
        public List<TurnManager> TurnOrder;
        public List<TurnManager> NextTurnOrder;
        public List<TurnManager> Swap;
        public List<GameObject> Entities;
        public bool Inturruptable { get; private set; }
        public bool requestInturrupt = false;
        public bool endBattle = false;
        public bool merging = false;

        private WaitUntil notMerging;
        private WaitForSeconds twoSeconds;
        private WaitUntil notRequestInturrupt;

        private void Awake()
        {
            TurnOrder = new List<TurnManager>();
            NextTurnOrder = new List<TurnManager>();
            Inturruptable = false;

            notMerging = new WaitUntil(() => !merging);
            twoSeconds = new WaitForSeconds(2f);
            notRequestInturrupt = new WaitUntil(() => !requestInturrupt);
        }

        void Start()
        {
            foreach (GameObject go in Entities)
            {
                if (!InformationManager.IsTemporaryTag(go.tag))
                {
                    TurnManager manager = go.GetComponent<TurnManager>();// InformationManager.GetRegisteredComponent(go, typeof(TurnTool)) as TurnTool;
                    if (manager != null)
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
                ToolManager tm = InformationManager.GetRegisteredToolManager(go);
                TurnManager turnTool = null;
                if (tm)
                {
                    turnTool = tm.Get(TurnManager.toolEnum) as TurnManager;
                }
                
                if (turnTool)
                {
                    BattleManager bm = turnTool.GetBattleManager();
                    if (bm != null && !bm.endBattle)
                    {
                        MergeBattles(bm);
                    }
                    else
                    {
                        if (turnTool.CanTakeTurn())
                        {
                            turnTool.CalculateInitiative();
                            AddOrdered(TurnOrder, turnTool, 1);
                            turnTool.SetBattleManager(this);
                        }
                    }
                }
            }
        }

        public void MergeBattles(BattleManager bm)
        {
            StartCoroutine(MergeBattleHelper(bm));
        }

        private IEnumerator MergeBattleHelper(BattleManager bm)
        {
            if (!bm.endBattle)
            {
                yield return notMerging;
                merging = true;
                bm.merging = true;
                requestInturrupt = true;
                bm.requestInturrupt = true;
                yield return (new WaitUntil(() => bm.Inturruptable && Inturruptable));
                yield return twoSeconds;
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
                bm.merging = false;
            }
        }

        private void MergeInitiative(List<TurnManager> main, List<TurnManager> other)
        {
            TurnManager em;
            if (other.Count == 0)
            {
                return;
            }
            for (int x = 0; x < main.Count; x++)
            {
                em = other[0];
                if (em.GetInitiative() > main[x].GetInitiative())
                {
                    main.Insert(x, em);
                    other.RemoveAt(0);
                    if (other.Count == 0)
                    {
                        return;
                    }
                    em = other[0];
                }
            }
            while (other.Count > 0)
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
            while (!BattleComplete())
            {
                Inturruptable = true;
                yield return notRequestInturrupt;
                Inturruptable = false;
                if (!endBattle)
                {
                    if (TurnOrder.Count < 1)
                    {
                        Swap = TurnOrder;
                        TurnOrder = NextTurnOrder;
                        NextTurnOrder = Swap;
                    }

                    if (TurnOrder.Count > 0)
                    {
                        TurnManager entityManager = TurnOrder[0];

                        TurnOrder.RemoveAt(0);
                        yield return StartCoroutine(entityManager.TakeTurn());

                        entityManager.CalculateInitiative();
                        AddOrdered(NextTurnOrder, entityManager, 0);
                    }

                    yield return null;
                }
            }
            Destroy(gameObject);
        }

        private bool BattleComplete()
        {
            return ((false /*&& !requestInturrupt*/) || (endBattle));
        }

        private bool AddOrdered(List<TurnManager> list, TurnManager unit, int start)
        {
            for (int x = start; x < list.Count; x++)
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
}