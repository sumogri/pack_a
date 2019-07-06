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

    /// <summary>
    /// スコアの最大値
    /// </summary>
    public int MaxScore { get; set; }

    public ScoreModel(int maxScore)
    {
        MaxScore = maxScore;
    }

    public int GetStar()
    {
        int star = 0;
        int scoreRate = Score * 100 / MaxScore;

        if (scoreRate > 50 && scoreRate < 65)
            star = 1;

        else if (scoreRate >= 65 && scoreRate < 80)
            star = 2;

        else if (scoreRate >= 80)
            star = 3;

        return star;
    }
}
