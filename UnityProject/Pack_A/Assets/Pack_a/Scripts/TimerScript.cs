using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace LinkingGirl.GameMain
{
    public class TimerScript : MonoBehaviour
    {
        [SerializeField] private Text timer = null;
        [SerializeField] private float limitSeconds = 3 * 60f;
        [SerializeField] private float dangerSeconds = 30f;
        [SerializeField] private AudioSource countSE;
        private int count = 3;
        public UnityEvent OnTimeUp;
        public UnityEvent OnDangerEnter;
        public bool isTimeUp = false;
        private bool isDanger = false;
        private float nowTime;
        public float SpendTime => limitSeconds - nowTime;

        // Use this for initialization
        void Start()
        {
            nowTime = limitSeconds;
            timer.text = GetTimeStr();
            //StartTimer();
        }

        public void StartTimer()
        {
            StartCoroutine(TimerCoroutine());
        }

        public void StopTimer()
        {
            StopAllCoroutines();
        }

        public string GetTimeStr()
        {
            return $"たいむ : {Mathf.FloorToInt(nowTime) / 60}:{Mathf.FloorToInt(nowTime) % 60,0:00}";
        }

        private IEnumerator TimerCoroutine()
        {
            while (nowTime > 0)
            {
                timer.text = GetTimeStr();
                yield return null;
                nowTime -= Time.deltaTime;

                if(isDanger == false && nowTime <= dangerSeconds)
                {
                    timer.color = Color.red;
                    OnDangerEnter.Invoke();
                    isDanger = true;
                }
                if(count > 0 && Mathf.FloorToInt(nowTime) <= count)
                {
                    count--;
                    countSE.Play();
                }
            }
            isTimeUp = true;
            nowTime = 0;
            timer.text = GetTimeStr();

            OnTimeUp.Invoke();
        }
    }
}