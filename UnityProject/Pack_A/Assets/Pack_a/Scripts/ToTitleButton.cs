using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToTitleButton : MonoBehaviour
{
    private readonly string SceneName = "Title";

    void Start()
    {
        gameObject.GetComponent<Button>()
            .onClick.AddListener(SceneChange);
    }

    private void SceneChange()
    {
        SceneManager.LoadScene(SceneName);
    }
}
