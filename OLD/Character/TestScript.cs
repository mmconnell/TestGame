using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour
{
    public int num = 0;
    void Awake()
    {
        Debug.Log("AWAKE:" +  num);
    }

    void OnEnable()
    {
        Debug.Log("ONENABLE:" + num);
    }
    // Use this for initialization
    void Start()
    {
        Debug.Log("START:" + num);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
