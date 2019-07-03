using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Text score;
    [Zenject.Inject] private ScoreModel model;

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
