using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UIActivater : MonoBehaviour
{
    [SerializeField] private GameObject[] onStartActivated = null;
    [SerializeField] private GameObject[] onRetryActivated = null;
    [Zenject.Inject] private GameModel model = null;
    
    // Start is called before the first frame update
    void Start()
    {
        model.OnStart.Subscribe(_ => OnStart());
        model.OnRetry.Subscribe(_ => OnRetry());
    }

    private void OnStart()
    {
        Activate(onStartActivated);
        DisActivate(onRetryActivated);
    }

    private void OnRetry()
    {
        Activate(onRetryActivated);
        DisActivate(onStartActivated);
    }

    private void Activate(GameObject[] objs)
    {
        foreach(var o in objs)
        {
            o.SetActive(true);
        }
    }

    private void DisActivate(GameObject[] objs)
    {
        foreach (var o in objs)
        {
            o.SetActive(false);
        }
    }
}
