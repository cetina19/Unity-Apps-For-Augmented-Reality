using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GetMethod : MonoBehaviour
{
    InputField outputArea;

    public void Start()
    {
        outputArea = GameObject.Find("OutputArea").GetComponent<InputField>();
        if (outputArea == null)
            Debug.Log("It is null");
        GameObject.Find("GetButton").GetComponent<Button>().onClick.AddListener(GetData);
    }

    public void GetData() => StartCoroutine(GetData_Coroutine());

    public IEnumerator GetData_Coroutine()
    {
        outputArea.text = "Loading...";
        string uri = "https://my-json-server.typicode.com/typicode/demo/posts";
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
                outputArea.text = request.error;
            else
                outputArea.text = request.downloadHandler.text;
        }
    }
}