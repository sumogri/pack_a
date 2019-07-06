using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スコアの数え上げ機能
/// </summary>
public class ScoreCounter : MonoBehaviour
{
    [Zenject.Inject] private ScoreModel model = null;
    private const string A_TAG = "A";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == A_TAG)
            model.Score++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == A_TAG)
            model.Score--;
    }
}
