using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using naichilab;

public class TwieetButton : MonoBehaviour
{
    [Zenject.Inject] private ScoreModel score;

    // Start is called before the first frame update
    void Start()
    {
        
        gameObject.GetComponent<Button>()
            .onClick.AddListener(() => Twieet());
    }

    private void Twieet()
    {
        UnityRoomTweet.Tweet("pack_a",$"{score.Score}個の'あ'を詰めました", "unityroom", "unity1week");
    }
}
