using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class IconLA : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    [Zenject.Inject] private GameModel game;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        rigidbody2D.simulated = false;
        game.OnStart.Subscribe(_ => rigidbody2D.simulated = true);
    }
}
