using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Zenject.Inject] private GameModel model = null;
    [SerializeField] private TimerScript timer = null;

    // Start is called before the first frame update
    void Start()
    {
        model.Init(timer);
        timer.OnTimeUp.AddListener(model.End);
    }
}
