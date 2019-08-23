using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectView : MonoBehaviour
{
    [SerializeField] private GameObject contentRoot;
    [SerializeField] private AudioSource se;

    public void Activate()
    {
        contentRoot.SetActive(true);
        se.Play();
    }

    public void Init()
    {
        contentRoot.SetActive(false);        
    }
}
