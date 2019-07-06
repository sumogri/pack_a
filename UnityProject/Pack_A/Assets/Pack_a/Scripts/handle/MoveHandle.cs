using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UniRx;

public class MoveHandle : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    [Zenject.Inject] private GameModel model;
    private bool isHolding = false;
    private Transform target;
    private float rotateDelta = 15;
    private Quaternion qRotateDelta;
    private Quaternion qRotateDeltaInv;
    private bool isPlaying = false;

    void Start()
    {
        target = transform;
        qRotateDelta = Quaternion.Euler(0, 0, rotateDelta);
        qRotateDeltaInv = Quaternion.Euler(0, 0, -1*rotateDelta);

        model.OnStart.Subscribe(_ => isPlaying = true);
        model.OnRetry.Subscribe(_ => isPlaying = false);
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
        if (!isHolding || isPlaying)
            return;

        var mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.z * -1;
        target.position = Camera.main.ScreenToWorldPoint(mousePos);

        var scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0) target.rotation *= qRotateDelta;
        if (scroll < 0) target.rotation *= qRotateDeltaInv;
    }
}
