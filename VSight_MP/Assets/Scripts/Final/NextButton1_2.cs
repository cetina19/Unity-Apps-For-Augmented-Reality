using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NextButton1_2 : MonoBehaviour
{
    public GameObject InfoCarrier1;
    public GameObject InfoCarrier2;
    public GameObject VirtualGallery;
    public GameObject ImageDisplayed;
    public GameObject CameraButton;

    static NextButton1_2 Instance;

    /*private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            //Destroy(gameObject);
        }
    }*/
    public void Information2()
    {
        //Text buffer = GameObject.Find("StepCount").GetComponent<Text>();
        if (!InfoCarrier2.active) {
            InfoCarrier1.SetActive(false);
            InfoCarrier2.SetActive(true);
            if (!ImageDisplayed.active)
            {
                VirtualGallery.SetActive(true);
                CameraButton.SetActive(true);
            }
            //ImageDisplayed.SetActive(true);
            
            //buffer.text = "1/9 - Step 2";
        }
        else if(!VirtualGallery.active)
        {
            //Awake();
            SceneManager.LoadScene("Step3");
            //buffer.text = "1/9 - Step 3";
        }
        
    }

    public void Information1()
    {
        InfoCarrier1.SetActive(true);
        InfoCarrier2.SetActive(false);
        VirtualGallery.SetActive(false);
        ImageDisplayed.SetActive(false);
        CameraButton.SetActive(false);
        Text buffer = GameObject.Find("StepCount").GetComponent<Text>();
        buffer.text = "1/9 - Step 1";
    }

    
}
