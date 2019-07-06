using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Text score = null;
    [Zenject.Inject] private ScoreModel model = null;

    void Start()
    {
        model.OnScoreChange
            .Throttle(TimeSpan.FromMilliseconds(100))
            .Subscribe(OnScoreUpdate); 
    }

    private void OnScoreUpdate(int score)
    {
        this.score.text = score.ToString();
    }
}
