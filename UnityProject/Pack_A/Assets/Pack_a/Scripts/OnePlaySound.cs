using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePlaySound : MonoBehaviour
{
    private AudioSource audioSource;
    private bool playnow = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!playnow && audioSource.isPlaying)
        {
            playnow = true;
        }

        if(playnow && !audioSource.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
