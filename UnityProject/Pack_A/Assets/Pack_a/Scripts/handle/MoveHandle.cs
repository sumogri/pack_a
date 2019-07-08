using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UniRx;

public class MoveHandle : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    private bool isHolding = false;
    private Transform target;
    private float rotateDelta = 15;
    private Quaternion qRotateDelta;
    private Quaternion qRotateDeltaInv;
    private bool isPlaying = false;
    [Zenject.Inject] private GameModel model = null;
    [SerializeField] private Color onMovable = new Color(0, 0.4470588f, 0.6980392f, 1);
    [SerializeField] private Color onNonMovable = Color.black;
    private Image image;

    void Start()
    {
        target = transform;
        qRotateDelta = Quaternion.Euler(0, 0, rotateDelta);
        qRotateDeltaInv = Quaternion.Euler(0, 0, -1*rotateDelta);

        model.OnStart.Subscribe(_ => OnStart());
        model.OnRetry.Subscribe(_ => OnRetry());
        image = gameObject.GetComponent<Image>();
    }

    private void OnStart()
    {
        isPlaying = true;
        image.color = onNonMovable;
    }

    private void OnRetry()
    {
        isPlaying = false;
        image.color = onMovable;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
        transform.SetAsLastSibling();
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
        var rotateInput = Input.GetAxis("Rotate");
        var isButtonDown = Input.GetButtonDown("Rotate");
        if (scroll > 0 || (isButtonDown && rotateInput > 0)) target.rotation *= qRotateDelta;
        else if (scroll < 0 || (isButtonDown && rotateInput < 0)) target.rotation *= qRotateDeltaInv;
    }
}
