using System;
using System.Collections.Concurrent;
using UnityEngine;

/// <summary>
///     Лёгкий раннер, который гарантированно исполняет действия на главном потоке Unity.
/// </summary>
internal sealed class _SspnetMainThreadRunner : MonoBehaviour
{
    private static _SspnetMainThreadRunner _instance;
    private static readonly ConcurrentQueue<Action> _queue = new();

    private void Update()
    {
        while (_queue.TryDequeue(out var a))
            try
            {
                a();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        if (_instance != null) return;

        var go = new GameObject("_SspnetMainThreadRunner");
        DontDestroyOnLoad(go);
        _instance = go.AddComponent<_SspnetMainThreadRunner>();
    }

    public static void Post(Action action)
    {
        if (action == null) return;
        _queue.Enqueue(action);
    }
}