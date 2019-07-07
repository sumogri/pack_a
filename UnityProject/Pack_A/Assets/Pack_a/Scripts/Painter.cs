using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Painter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "A") return;

        collision.tag = "Black";
        var tm = collision.GetComponent<TextMeshProUGUI>();
        tm.text = "●";
        tm.fontSize = 2.25f;
    }
}
