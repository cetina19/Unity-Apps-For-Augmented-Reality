using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool stop = true;

    void Start()
    {
        startTime = 4 * 60;
    }

    void Update()
    {
        if (!stop && Time.time<=startTime){
            float t = startTime - Time.time;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            timerText.text = "Duration: " + minutes + ":" + seconds;
        }
    }

    public void Stop_Timer()
    {
        stop = !stop;
    }
}
