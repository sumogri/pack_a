using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Zenject.Inject] private GameModel model = null;
    [SerializeField] private TimerScript timer = null;
    [SerializeField] private Button startButton = null;
    [SerializeField] private Button retryButton = null;

    // Start is called before the first frame update
    void Start()
    {
        model.Init(timer);

        startButton.onClick.AddListener(model.Start);
        retryButton.onClick.AddListener(model.Retry);
        timer.OnTimeUp.AddListener(model.End);
    }
}
