using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using TMPro;

public class ReadFileJSON : MonoBehaviour
{
    
    //public TextAsset JSON_text;

    [System.Serializable]
    public class JSONData
    {
        public string name;
        public int number;
    }

    [System.Serializable]
    public class DataList
    {
        public List<JSONData> datas;
    }

    //public Player[] readDataList = new PlayerList();
    // Start is called before the first frame update
    void Start()
    {
        string FilePath = Application.streamingAssetsPath + "/Recall_Chat/" + "Strings" + ".json";//+ "/Json/" + "Strings" + ".json";
        string jsonString = File.ReadAllText(FilePath);
        DataList readDataList = JsonUtility.FromJson<DataList>(FilePath);
        /*Debug.Log(readDataList.datas[0].name);
        foreach(JSONData data in readDataList.datas) 
        {
            Debug.Log(data.number);
            Debug.Log("Hey");
        }*/
        //Debug.Log(readDataList.data[0]);
        //List<string> fileLines = File.ReadAllLines(FilePath).ToList();

        //readDataList = JsonUtility.FromJson<DataList>(JSONtext.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
