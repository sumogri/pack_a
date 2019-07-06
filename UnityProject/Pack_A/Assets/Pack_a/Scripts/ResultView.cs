using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class ResultView : MonoBehaviour
{
    [Zenject.Inject] private ScoreModel score;
    [Zenject.Inject] private GameModel game;
    [SerializeField] private GameObject contetntRoot;
    [SerializeField] private TextMesh scoreText;
    [SerializeField] private StarView star1;
    [SerializeField] private StarView star2;
    [SerializeField] private StarView star3;
    [SerializeField] private GameObject[] activatedObjs;

    // Start is called before the first frame update
    void Start()
    {
        game.OnEnd.Subscribe(_ => OnEnd());
        game.OnRetry.Subscribe(_ => OnRetry());
    }

    private void OnEnd()
    {        
        StartCoroutine(ActivateColoutine());
    }

    private void OnRetry()
    {
        star1.Init();
        star2.Init();
        star3.Init();
        foreach(var o in activatedObjs)
        {
            o.SetActive(false);
        }
    }

    private IEnumerator ActivateColoutine()
    {
        scoreText.text = score.Score.ToString();
        foreach (var o in activatedObjs)
        {
            o.SetActive(false);
        }

        yield return null;
    }
}
