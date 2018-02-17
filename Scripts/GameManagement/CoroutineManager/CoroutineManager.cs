using UnityEngine;
using System;
using System.Collections;

public class CoroutineManager : MonoBehaviour
{
    private static CoroutineManager coroutineManager;

    public static CoroutineManager Instance
    {
        get
        {
            if (!coroutineManager)
            {
                coroutineManager = FindObjectOfType(typeof(CoroutineManager)) as CoroutineManager;

                if (!coroutineManager)
                {
                    Debug.LogError("There needs to be one active CoroutineManager script on a GameObject in your scene.");
                }
                else
                {
                    coroutineManager.Init();
                }
            }

            return coroutineManager;
        }
    }

    void Init()
    {
       
    }
    /**
     * Usage: StartCoroutine(CoroutineUtils.Chain(...))
     * For example:
     *     StartCoroutine(CoroutineUtils.Chain(
     *         CoroutineUtils.Do(() => Debug.Log("A")),
     *         CoroutineUtils.WaitForSeconds(2),
     *         CoroutineUtils.Do(() => Debug.Log("B"))));
     */
    public static IEnumerator Chain(params IEnumerator[] actions)
    {
        foreach (IEnumerator action in actions)
        {
            yield return Instance.StartCoroutine(action);
        }
    }

    /**
     * Usage: StartCoroutine(CoroutineUtils.DelaySeconds(action, delay))
     * For example:
     *     StartCoroutine(CoroutineUtils.DelaySeconds(
     *         () => DebugUtils.Log("2 seconds past"),
     *         2);
     */
    public static IEnumerator DelaySeconds(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action();
    }

    public static IEnumerator WaitForSeconds(float time)
    {
        yield return new WaitForSeconds(time);
    }

    public static IEnumerator Do(Action action)
    {
        action();
        yield return 0;
    }
}
