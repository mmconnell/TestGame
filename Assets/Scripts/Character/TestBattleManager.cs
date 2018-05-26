using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestBattleManager : MonoBehaviour
{

    int count = 0;
    public GameObject battleManagers;
    private BattleManager bm1;
    private BattleManager bm2;
    private List<BattleManager> bms;
    public GameObject Players;
    public int[] test = new int[3];
    // Use this for initialization
    void Start()
    {
        bms = new List<BattleManager>();
        for(int i = 0; i < test.Length; i++)
        {
            List<GameObject> go = new List<GameObject>(test[i]);
            for(int x = 0; x < test[i]; x++)
            {
                go.Add(CreatePlayer());
            }
            GameObject bm = CreateBattle(go);
            bm.name = "BATTLE " + i;
            bms.Add(bm.GetComponent<BattleManager>());
        }
        bm1 = bms[0];
        bm2 = bms[1];
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
        GameObject go = new GameObject("Dummy");
        go.AddComponent<CharacterManager>();
        go.AddComponent<TurnTool>();
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
