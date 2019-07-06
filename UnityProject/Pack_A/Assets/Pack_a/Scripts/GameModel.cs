using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameModel
{
    private ScoreModel score;
    private TimerScript timer;

    public IObservable<Unit> OnStart => onStartSubject;
    private Subject<Unit> onStartSubject = new Subject<Unit>();
    public IObservable<Unit> OnRetry => onRetrySubject;
    private Subject<Unit> onRetrySubject = new Subject<Unit>();
    public IObservable<int> OnEnd => onEndSubject;
    private Subject<int> onEndSubject = new Subject<int>();

    public GameModel(ScoreModel score)
    {
        this.score = score;
    }

    public void Init(TimerScript timer)
    {
        this.timer = timer;
    }

    public void Start()
    {
        timer.StartTimer();
        onStartSubject.OnNext(Unit.Default);
    }

    public void Retry()
    {
        timer.ResetTimer();
        onRetrySubject.OnNext(Unit.Default);
    }

    public void End()
    {
        timer.StopTimer();
        onEndSubject.OnNext(score.Score);
    }

    public void BackToSelect()
    {

    }
}
