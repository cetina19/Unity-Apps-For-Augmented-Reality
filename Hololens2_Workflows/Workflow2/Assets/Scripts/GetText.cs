using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using TMPro;

public class GetText : MonoBehaviour
{
    public Transform contentWindow;

    public GameObject RecallText;

    private void Start()
    {
        string readFromFilePath = Application.streamingAssetsPath + "/Recall_Chat/" + "Chat" + ".txt";

        List<string> fileLines = File.ReadAllLines(readFromFilePath).ToList();

        foreach (string line in fileLines)
        {
            //Debug.Log(line);
            Instantiate(RecallText, contentWindow);
            RecallText.GetComponent<TMP_Text>().text = line;
        }
    }
}
