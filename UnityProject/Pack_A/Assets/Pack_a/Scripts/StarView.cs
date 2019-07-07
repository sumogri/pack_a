using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarView : MonoBehaviour
{
    [SerializeField] private Color activeColor = new Color(1,0.49f,0);
    [SerializeField] private GameObject effect;
    [SerializeField] private AudioSource audioSource;
    private Color defaultColor = Color.black;
    private Image image;

    private void Start()
    {
        image = gameObject.GetComponent<Image>();
        defaultColor = image.color;
    }

    public void Activate()
    {
        image.color = activeColor;
        effect.SetActive(true);
        audioSource.Play();
    }

    public void Init()
    {
        image.color = defaultColor;
        effect.SetActive(false);
    }
}
