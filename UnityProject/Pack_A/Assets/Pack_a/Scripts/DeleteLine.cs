using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteLine : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("go");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter");
        Destroy(other.gameObject);
    }
}
