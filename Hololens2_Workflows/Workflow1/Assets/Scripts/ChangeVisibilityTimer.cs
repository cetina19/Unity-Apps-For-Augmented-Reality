using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVisibilityTimer : MonoBehaviour
{
    // Start is called before the first frame update
    Text TimerRender;
    void Start()
    {
        TimerRender = GameObject.Find("Timer_Text").GetComponent<Text>();
        TimerRender.enabled=true;
    }

    // Update is called once per frame
    public void onClickedEvent()
    {
        TimerRender.enabled = !TimerRender.enabled;
    }
}
