using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoveHandle : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    private bool isHolding = false;
    private Transform target;

    void Start()
    {
        target = transform;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
    }

    void Update()
    {
        if (!isHolding)
            return;

        var mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.z * -1;
        target.position = Camera.main.ScreenToWorldPoint(mousePos);

        var scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0) target.rotation *= Quaternion.Euler(0, 0, 30);
        if (scroll < 0) target.rotation *= Quaternion.Euler(0, 0, -30);
    }
}
