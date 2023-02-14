using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class JsonExample : MonoBehaviour
{
    [System.Serializable]
    public class dummy
    {
        public string name;
        public int number;
        //public int number2;
    }

    [System.Serializable]
    public class dummyList
    {
        public dummy[] dummy;
    }
    //string path;
    public TextAsset jsonString;
    public dummyList mydummyList = new dummyList();
    public Transform contentWindow;
    public GameObject WrittenText;
    //[SerializeField] TextAsset buffer;
    private void Start()
    {
        //mydummyList.player = new dummy[] {};
        mydummyList = JsonUtility.FromJson<dummyList>(jsonString.text);
        //path = Application.streamingAssetsPath + "/Json/" + "Strings.text";
        //jsonString = File.ReadAllText(path);
        //dummy example1 = new dummy();
        //example1.name = "Alper";
        //example1 = JsonUtility.FromJson<dummy>(jsonString);
        //print(mydummyList);
        //WrittenText.GetComponent<TMP_Text>().text = "";
        //for(int i=0;i<2;i++) {
        foreach(dummy buffer in mydummyList.dummy) { 
            //Debug.Log(buffer.number);
            WrittenText.GetComponent<Text>().text = buffer.name;
            WrittenText = (GameObject)Instantiate(WrittenText, contentWindow);
            
        }
        //WrittenText.GetComponent<TMP_Text>().text = "";

    }
}

/*
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
 */