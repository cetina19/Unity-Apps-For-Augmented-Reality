using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BtnClick : MonoBehaviour
{
    public TMP_Text TextField;

    public void SetText(string text) { TextField.text = text; }
}
