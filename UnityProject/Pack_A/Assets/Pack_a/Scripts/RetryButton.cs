using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class RetryButton : MonoBehaviour
{
    [Zenject.Inject] private GameModel model = null;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        model.OnStart.Subscribe(_ => OnStart());
        model.OnRetry.Subscribe(_ => OnRetry());
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(() => model.Retry());
    }

    private void OnStart()
    {
        button.interactable = true;
    }
    private void OnRetry()
    {
        button.interactable = false;
    }
}
