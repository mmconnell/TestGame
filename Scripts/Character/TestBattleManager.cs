using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Manager;

public class TestBattleManager : MonoBehaviour
{

    int count = 0;
    public GameObject battleManagers;
    private BattleManager bm1;
    private BattleManager bm2;
    private List<BattleManager> bms;
    public GameObject Players;
    public int[] test = new int[3];
    public GameObject player;
    public GameObject enemy;
    private int numPlayers = 1;
    private int battlesBuilt = 0;
    private bool useEnemy = false;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Initialize());
    }

    IEnumerator Initialize()
    {
        yield return StartCoroutine(BuildBattles());
        if (bms.Count > 0)
        {
            bm1 = bms[0];
        }
        if (bms.Count > 1)
        {
            bm2 = bms[1];
        }
    }

    IEnumerator BuildBattles()
    {
        while (!BattleDone())
        {
            bms = new List<BattleManager>();
            for (int i = 0; i < test.Length; i++)
            {
                StartCoroutine(BuildBattle(i));
            }
            yield return null;
        }
    }

    bool BattleDone()
    {
        return battlesBuilt == test.Length;
    }

    IEnumerator BuildBattle(int index)
    {
        List<GameObject> go = new List<GameObject>(test[index]);
        for (int x = 0; x < test[index]; x++)
        {
            go.Add(CreatePlayer());
        }
        GameObject bm = CreateBattle(go);
        bm.name = "BATTLE " + index;
        bms.Add(bm.GetComponent<BattleManager>());
        battlesBuilt++;
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (bm2 != null)
            {
                bm1.MergeBattles(bm2);
                bms.Remove(bm2);
                if(bms.Count > 1)
                {
                    bm2 = bms[1];
                } else
                {
                    bm2 = null;
                }
                count = 0;
            }
            count++;
        }
    }

    private GameObject CreatePlayer()
    {
        GameObject go;
        if (useEnemy)
        {
            go = Instantiate(enemy, new Vector3(0, 0, 0), Quaternion.identity);
            go.name = "Enemy Test " + numPlayers;
            useEnemy = false;
        }
        else
        {
            go = Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
            go.name = "Player Test " + numPlayers;
            useEnemy = true;
        }
        
        numPlayers++;
        go.AddComponent<TurnManager>();
        go.transform.position = new Vector3(0, 0, 0);
        go.transform.parent = Players.transform;
        return go;
    }

    private GameObject CreateBattle(List<GameObject> players)
    {
        GameObject go = new GameObject("Battle");
        go.AddComponent<BattleManager>().Entities = players;
        go.transform.parent = battleManagers.transform;
        return go;
    }
}
