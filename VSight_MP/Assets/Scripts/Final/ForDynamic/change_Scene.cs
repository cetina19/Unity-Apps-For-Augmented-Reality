using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_Scene : MonoBehaviour
{
    public void changeNext()
    {
        if(Steps.index < Steps.stepCount)
        {
            Steps.stepPrevious.Add(Steps.stepName);
            Steps.stepName = Steps.buffer.Data[0].Steps[Steps.stepName].Data.Next;
            Steps.InfoObject.GetComponent<Text>().text = "Loading..";
            //Debug.Log(Steps.stepName);
            Steps.index++;
        }
            
    }
    public void changePrevious()
    {
        if (Steps.stepName != Steps.buffer.Data[0].InitialStep)
        {
            Steps.stepName = Steps.stepPrevious[^1];//Steps.buffer.Data[0].;
            Steps.stepPrevious.Remove(Steps.stepName);
            Steps.InfoObject.GetComponent<Text>().text = "Loading..";
            Steps.index--;
            //Steps.buffer.Data[0].Steps[Steps.stepName].Data.
        }
    }
}
