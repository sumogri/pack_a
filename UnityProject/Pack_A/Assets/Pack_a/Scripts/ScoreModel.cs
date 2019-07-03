using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ScoreModel
{
    /// <summary>
    /// カップに入っている"あ"の数
    /// </summary>
    public int Score {
        get { return reactiveScore.Value; }
        set { reactiveScore.Value = value; }
    }
    public IObservable<int> OnScoreChange => reactiveScore;
    private ReactiveProperty<int> reactiveScore = new ReactiveProperty<int>();

}
