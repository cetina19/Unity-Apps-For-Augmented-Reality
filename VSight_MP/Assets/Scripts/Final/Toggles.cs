using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggles : MonoBehaviour
{
    // Start is called before the first frame update
    public void Clicked()
    {
        Debug.Log(this.transform.GetChild(1).GetComponent<Text>().text);
    }
}
