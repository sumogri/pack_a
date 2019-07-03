using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AGenerater : MonoBehaviour
{
    [SerializeField] private GameObject aPrefab;
    [SerializeField] private bool isGenerate = true;
    [SerializeField] private float spanSec = 1;
    private float time = 0;
    
    private void Update()
    {
        time += Time.deltaTime;

        if (!isGenerate || time < spanSec)
            return;

        time = 0;
        Instantiate(aPrefab, transform);
    }

    [Conditional("UNITY_EDITOR")]
    private void OnDrawGizmos()
    {
        
    }
}
