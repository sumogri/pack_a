using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AView : MonoBehaviour
{
    [SerializeField] private AudioSource hiteff;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!hiteff.isPlaying)
           hiteff.Play();
    }
}
