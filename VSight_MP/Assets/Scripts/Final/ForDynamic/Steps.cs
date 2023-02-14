using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine.Video;

public class Steps : MonoBehaviour
{
    public static WorkFlow.Unity buffer;
    string UnityUrl = "https://us-central1-vsight-remote-angular-release.cloudfunctions.net/workflowGetList2?key=Ls54ew0nJ23fLm5k&account=-N7VDmTNL0c0Sq1i27Wm";

    public bool startChecker = true;
    GameObject Infoparent;
    public static GameObject InfoObject;
    GameObject MiddleParent;
    GameObject videoBuffer;
    GameObject imageBuffer;     //can be array
    GameObject optionsBuffer;
    RawImage thisRender;
    Renderer imageRenderer;
    bool playVideo = false;

    public static int index = 1, stepCount = 9;
    public static string stepName;
    public static List<string> stepPrevious;
    Font standardFont;
    RenderTexture standardTexture;
    Material standardMaterial;
    GameObject toggleTemp;
    void Start()
    {
        standardFont = Resources.Load<Font>("standardFont");
        standardTexture = Resources.Load<RenderTexture>("StandardTexture");
        standardMaterial = Resources.Load<Material>("standardMaterial");
        toggleTemp = Resources.Load<GameObject>("optionTemp");
        //stepPrevious = new Vec
        if (startChecker)
        {
            stepPrevious = new List<string>();
            GameObject.Find("Header").GetComponent<Text>().text = "Loading...";
            MiddleParent = GameObject.Find("MiddlePanel");
            if (InfoObject == null)
                InfoObject = new GameObject("Buffer");

            InfoObject.transform.SetParent(MiddleParent.transform);

            InitiateText(InfoObject, new Vector3(0, 0, 0));
            GetDataSteps();
            startChecker = false;
        }
    }

    private void Update()
    {
        if (buffer == null)
            return;
        if(GameObject.Find("StepCount").GetComponent<Text>().text != ("Step " + index))
        {
            GameObject.Find("StepCount").GetComponent<Text>().text = "Step " + index;
            GetDataSteps();
            
        }
        if (InfoObject != null)
            InfoObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(
                InfoObject.GetComponent<RectTransform>().rect.width * 3 / 4, 0, 0);

        if (videoBuffer != null)
        {
            videoBuffer.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        }
        
        if (InfoObject.GetComponent<Text>().text != "Loading...")
            InfoObject.GetComponent<Text>().font = standardFont;
        if (buffer == null)
            Debug.Log("Warning is detected");
    }

    private void InitiateText(GameObject temp, Vector3 location)
    {
        temp.AddComponent<RectTransform>();
        temp.AddComponent<Text>();
        //temp.AddComponent<ContentSizeFitter>();
        temp.AddComponent<BoxCollider2D>();
        temp.AddComponent<Mask>();

        //temp.GetComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        //temp.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        temp.GetComponent<RectTransform>().sizeDelta = new Vector2(480,15);
        temp.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
        temp.GetComponent<RectTransform>().anchorMin = new Vector2(0.05f, 0.70f);
        temp.GetComponent<RectTransform>().anchorMax = new Vector2(0.05f, 0.9f);
        temp.GetComponent<RectTransform>().anchoredPosition = location;
        temp.GetComponent<Text>().text = "Loading...";
        temp.GetComponent<Text>().font = standardFont;

    }
    public void GetDataSteps() 
    {
        StartCoroutine(GetData_Coroutine()); 
    }

    public IEnumerator GetData_Coroutine()
    {
        string uri = UnityUrl;
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
                Debug.Log("Error");//outputArea.text = request.error;
            else if(buffer==null)
            {
                string temp = request.downloadHandler.text;
                buffer = WorkFlow.Unity.FromJson(temp);
            }
        }
        //stepName = "Step " + index;

        GameObject.Find("StepCount").GetComponent<Text>().text = "Step " + index;
        if (index == 1)
        {
            GameObject.Find("Header").GetComponent<Text>().text = buffer.Data[0].Name;
            stepName = buffer.Data[0].InitialStep;
            stepPrevious.Add(stepName);
            stepCount = buffer.Data[0].Steps.Count;
        }
        
        InfoObject.GetComponent<Text>().text = buffer.Data[0].Steps[stepName].Data.Layouts[0].Items[0].TemplateOptions.Label;

        int layoutIndex = 0;
        while(layoutIndex < buffer.Data[0].Steps[stepName].Data.Layouts.Length)
        {
            if (buffer.Data[0].Steps[stepName].Data.Layouts[layoutIndex].Items[0].TemplateOptions.ImgUrl != null ||
                buffer.Data[0].Steps[stepName].Data.Layouts[layoutIndex].Items[0].TemplateOptions.VideoUrl != null ||
                buffer.Data[0].Steps[stepName].Data.Layouts[layoutIndex].Items[0].TemplateOptions.Options != null)
                break;
            else if (layoutIndex == buffer.Data[0].Steps[stepName].Data.Layouts.Length-1)
                break;
            layoutIndex++;
        }
        Debug.Log(stepName);

        if(buffer.Data[0].Steps[stepName].Data.Layouts[layoutIndex].Items[0].TemplateOptions.Options != null)
        {

            if (optionsBuffer == null)
                InitiateOptions(new Vector3(0, 0, 0), layoutIndex);
        }
        else
        {
            if(optionsBuffer != null)
                if (optionsBuffer.active)
                    optionsBuffer.SetActive(false);
        }

        if (buffer.Data[0].Steps[stepName].Data.Layouts[layoutIndex].Items[0].TemplateOptions.ImgUrl != null)
        {
            Debug.Log(stepName);
            if (imageBuffer == null)
                InitiateImage("imageBuffer", new Vector3(0, -20, 0));
            else
                imageBuffer.SetActive(true);

            string imgURL = buffer.Data[1].Steps["wY17SxERuFbVupEqkWNd"].Data.Layouts[0].Items[0].TemplateOptions.ImgUrl;
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(imgURL);
            yield return www.SendWebRequest();
            Texture myTexture = DownloadHandlerTexture.GetContent(www);

            imageBuffer.GetComponent<RawImage>().texture = myTexture;
        }
        else// (buffer.Data[0].Steps[stepName].Data.Layouts[layoutIndex].Items[0].TemplateOptions.ImgUrl == null)
        {
            if (imageBuffer != null)
                if(imageBuffer.active)
                    imageBuffer.SetActive(false);
        }

        if (buffer.Data[0].Steps[stepName].Data.Layouts[layoutIndex].Items[0].TemplateOptions.VideoUrl != null && videoBuffer==null)
        {
            Debug.Log("There is a video in the scene");
            if (videoBuffer == null)
            {
                InitiateVideo("videoBuffer", new Vector3(0, 20, 40));
                videoBuffer.transform.SetParent(MiddleParent.transform);
            }
            else
                videoBuffer.SetActive(true);
            
        }
        else// (buffer.Data[0].Steps[stepName].Data.Layouts[layoutIndex].Items[0].TemplateOptions.VideoUrl==null) 
        {
            if (videoBuffer != null)
                if(videoBuffer.active)
                    videoBuffer.SetActive(false);
        }

        
    }

    void InitiateVideo(string videoName, Vector3 location) {
        videoBuffer = new GameObject(videoName);
        videoBuffer.AddComponent<RectTransform>();
        videoBuffer.AddComponent<VideoPlayer>();
        videoBuffer.AddComponent<Button>();
        //videoBuffer.GetComponent<Button>().onClick.AddListener(buttonClick(videoBuffer.GetComponent<Button>(),new EventArgs e));
        videoBuffer.GetComponent<Button>().onClick.AddListener(Stop_Play);
        videoBuffer.AddComponent<RawImage>();
        videoBuffer.GetComponent<RectTransform>().anchoredPosition = location;
        videoBuffer.GetComponent<RawImage>().texture = standardTexture;//new RenderTexture(6, 6, 6, RenderTextureFormat.ARGB32);
        videoBuffer.GetComponent<VideoPlayer>().targetTexture = standardTexture;
        string videoURL = buffer.Data[0].Steps[stepName].Data.Layouts[0].Items[0].TemplateOptions.VideoUrl;
        //videoURL = "https://www.youtube.com/watch?v=nADTdV8wsXQ";
        videoBuffer.GetComponent<VideoPlayer>().url = videoURL;
        videoBuffer.GetComponent<VideoPlayer>().audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoBuffer.GetComponent<VideoPlayer>().EnableAudioTrack(0, true);
        videoBuffer.GetComponent<VideoPlayer>().Prepare();
        videoBuffer.GetComponent<VideoPlayer>().Pause();
        videoBuffer.GetComponent<RectTransform>().sizeDelta = new Vector2(2.1f * videoBuffer.GetComponent<RectTransform>().sizeDelta.x, 2.1f * videoBuffer.GetComponent<RectTransform>().sizeDelta.y);
        
        //Shader shader;
        //videoBuffer.GetComponent<RawImage>().color = new Color(256,0,256);//.material = new Material(shader);
        //videoObject.gameObject.GetComponent<RenderTexture>() = standardTexture;
    }

    void InitiateImage(string imageName, Vector3 location)
    {
        imageBuffer = new GameObject(imageName);
        if (imageBuffer == null)
            Debug.Log("Image buffer is null");
        imageBuffer.transform.SetParent(MiddleParent.transform);
        imageBuffer.AddComponent<RectTransform>();
        imageBuffer.AddComponent<RawImage>();
        imageBuffer.GetComponent<RectTransform>().anchoredPosition = location;
        imageBuffer.GetComponent<RectTransform>().sizeDelta = new Vector2(1.8f * imageBuffer.GetComponent<RectTransform>().sizeDelta.x, 1.18f * imageBuffer.GetComponent<RectTransform>().sizeDelta.y);

    }

    void InitiateOptions(Vector3 location, int index)
    {
        optionsBuffer = new GameObject("optionsBuffer");
        optionsBuffer.transform.SetParent(MiddleParent.transform);
        optionsBuffer.AddComponent<RectTransform>();
        optionsBuffer.AddComponent<VerticalLayoutGroup>();
        optionsBuffer.AddComponent<LayoutElement>();
        optionsBuffer.GetComponent<VerticalLayoutGroup>().childForceExpandHeight = true;
        optionsBuffer.GetComponent<LayoutElement>().minHeight=20;
        optionsBuffer.GetComponent<RectTransform>().anchoredPosition = location;
        
        for (int i=0;i< buffer.Data[0].Steps[stepName].Data.Layouts[index].Items[0].TemplateOptions.Options.Length;i++)
        {
            InitiateOption("option "+(i+1));
            optionsBuffer.transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().color = Color.white;
            optionsBuffer.transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = buffer.Data[0].Steps[stepName].Data.Layouts[index].Items[0].TemplateOptions.Options[i].Value;
        }

        
    }

    void InitiateOption(string name)
    {

        GameObject option = Instantiate(toggleTemp); ; //= new GameObject(name);
        /*option.AddComponent<UnityEngine.UI.Toggle>();
        option.AddComponent<RectTransform>();
        option.GetComponent<RectTransform>().sizeDelta = new Vector2(40,40);
        option.GetComponent<Toggle>().graphic = toggleTemp.GetComponent<Toggle>().graphic;
        option.GetComponent<Toggle>().targetGraphic = toggleTemp.GetComponent<Toggle>().targetGraphic;
        option.GetComponent<Toggle>().name = name;*/
        option.transform.GetChild(1).GetComponent<Text>().text = "";
        option.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,0,0);
        option.AddComponent<Mask>();
        //option.AddComponent<Re>();
        /*option.AddComponent<RectTransform>();
        option.AddComponent<Toggle>();
        option.GetComponent<Toggle>().isOn = true;*/
        option.transform.SetParent(optionsBuffer.transform);
    }

    public void Stop_Play()
    {
        //create an instance of button based on sender object
        playVideo = !playVideo;
        if (playVideo)
            videoBuffer.GetComponent<VideoPlayer>().Play();
        else
            videoBuffer.GetComponent<VideoPlayer>().Pause();
        //display the name of button and text in it
        //MessageBox.Show($"You have clicked '{btn.Name}' with text= '{btn.Text}'")
    }

}