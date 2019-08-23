using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Async;

public class ResultView : MonoBehaviour
{
    [Zenject.Inject] private ScoreModel score;
    [Zenject.Inject] private GameModel game;
    [SerializeField] private GameObject contentRoot;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private StarView star1;
    [SerializeField] private StarView star2;
    [SerializeField] private StarView star3;
    [SerializeField] private PerfectView perfect;
    [SerializeField] private GameObject[] activatedObjs;
    private bool isActivated = false;
    
    // Start is called before the first frame update
    void Start()
    {
        game.OnEnd.Subscribe(async _ => await OnEnd());
        game.OnRetry.Subscribe(_ => OnRetry());
    }

    private async UniTask OnEnd()
    {
        await Activate();
    }

    private void OnRetry()
    {
        if (!isActivated)
            return;

        star1.Init();
        star2.Init();
        star3.Init();
        perfect.Init();
        foreach(var o in activatedObjs)
        {
            o.SetActive(false);
        }
        contentRoot.SetActive(false);

        isActivated = false;
    }

    private async UniTask Activate()
    {
        isActivated = true;
        contentRoot.SetActive(true);
        scoreText.text = score.Score.ToString();
        var starCount = score.GetStar();

        if(starCount >= 1)
        { 
            await UniTask.Delay(100);
            star1.Activate();
        }

        if (starCount >= 2)
        {
            await UniTask.Delay(100);
            star2.Activate();
        }

        if (starCount >= 3)
        {
            await UniTask.Delay(100);
            star3.Activate();
        }

        if (score.IsPerfect)
        {
            await UniTask.Delay(100);
            perfect.Activate();
        }

        await UniTask.Delay(100);
        foreach (var o in activatedObjs)
        {
            o.SetActive(true);
        }
    }
}
