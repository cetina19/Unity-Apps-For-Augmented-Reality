using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stop_Signal : MonoBehaviour
{
    public Text changedText;
    // Start is called before the first frame update
    public void Stopper()
    {
        GameObject.Find("Timer_Object").SendMessage("Stop_Timer");
        if (changedText.text == "Start")
            changedText.text = "Stop";
        else
        {
            changedText.text = "Start";
            SceneManager.LoadScene(3);
        }
    }
}
