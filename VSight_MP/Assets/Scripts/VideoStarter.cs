using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoStarter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject video;
    public RawImage firstScene;
    private VideoPlayer stopandplay;
    public Text oldText;
    bool active = false;
    void Start()
    {
        //oldText.enabled = true;
        firstScene.enabled = false;
        video.SetActive(active);
        stopandplay = video.GetComponent<VideoPlayer>();
        //stopandplay.Pause();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartVideo()
    {
        active = !active;
        firstScene.enabled=true;
        video.SetActive(true);
        if(active)
            stopandplay.Play();
        else
            stopandplay.Pause();
        //video.SetActive(active);
        //oldText.enabled = false;
    }
    private void OnDestroy()
    {
        //Debug.Log("It ended");
        video.SetActive(false);
        firstScene.enabled = false;
    }
}
