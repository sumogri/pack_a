using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using naichilab;

public class TwieetButton : MonoBehaviour
{
    [Zenject.Inject] private ScoreModel score;
    [SerializeField] private string stageName;

    // Start is called before the first frame update
    void Start()
    {        
        gameObject.GetComponent<Button>()
            .onClick.AddListener(() => Twieet());
    }

    private void Twieet()
    {
        var content = $"ステージ{stageName}で、{score.Score}個の'あ'を詰めました";
        UnityRoomTweet.Tweet("pack_a",content, "unityroom", "unity1week");
    }
}
