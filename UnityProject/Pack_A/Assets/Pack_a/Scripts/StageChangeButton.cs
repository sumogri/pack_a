using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageChangeButton : MonoBehaviour
{
    private readonly string stageSceneNamePrefix = "Stage";
    [SerializeField] private string stageNo;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>()
            .onClick.AddListener(SceneChange);
    }

    private void SceneChange()
    {
        SceneManager.LoadScene(stageSceneNamePrefix + stageNo);
    }
}
