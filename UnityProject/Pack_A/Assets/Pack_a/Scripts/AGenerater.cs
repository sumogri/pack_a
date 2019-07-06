using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UniRx;

public class AGenerater : MonoBehaviour
{
    [SerializeField] private GameObject aPrefab = null;
    [SerializeField] private bool isGenerate = true;
    [SerializeField] private float spanSec = 1;
    [SerializeField] private int maxGenerate = 15;
    private int nowGenerateCounter = 0;
    private float time = float.PositiveInfinity;
    [Zenject.Inject] private GameModel gameModel = null;
    private Stack<GameObject> generatedObjs = new Stack<GameObject>();

    private void Start()
    {
        time = spanSec;
        gameModel.OnStart.Subscribe(_ => OnStart());
        gameModel.OnRetry.Subscribe(_ => OnRetry());
    }

    private void Update()
    {
        if (!isGenerate) return;

        time += Time.deltaTime;

        if (time < spanSec)
            return;

        time = 0;
        var i = Instantiate(aPrefab, transform.parent);
        i.transform.position = transform.position;
        generatedObjs.Push(i);

        nowGenerateCounter++;
        //指定個数生成したら、休止
        if (nowGenerateCounter >= maxGenerate) {
            Init();
        }
    }

    private void Init()
    {
        isGenerate = false;
        nowGenerateCounter = 0;
        time = spanSec;
    }

    private void OnRetry()
    {
        Init();

        while(generatedObjs.Count != 0)
        {
            var o = generatedObjs.Pop();
            if (o != null)
                Destroy(o);
        }
    }

    private void OnStart()
    {
        isGenerate = true;
    }

    [Conditional("UNITY_EDITOR")]
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position,Vector3.one);
    }
}
