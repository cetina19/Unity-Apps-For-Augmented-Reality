using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using "NextButton1_2.cs";

public class ChangeScene : MonoBehaviour
{
    //NextButton1_2 buffer;
    public void ChangeNext()
    {
        string SceneName = SceneManager.GetActiveScene().name;
        switch (SceneName)
        {
            case "Step1":
                SceneManager.LoadScene("Step2");
                break;
            case "Step2":
                SceneManager.LoadScene("Step3");
                break;
            case "Step3":
                SceneManager.LoadScene("Step4");
                break;
            case "Step4":
                SceneManager.LoadScene("Step5");
                //SceneManager.LoadScene("Assets/Scenes/Final/Step5.unity");
                /*SceneManager.EditorSceneManager.OpenScene(
        AssetDatabase.GUIDToAssetPath(
            AssetDatabase.FindAssets("t:SceneAsset " + MenuSceneName,new string[] { "Assets" })[0]));*/
                //EditorSceneManager.LoadSceneAsyncInPlayMode()
                //SceneManager.LoadScene("Step5");
                break;
            default:
                break;
        }

        /*int i = SceneManager.GetActiveScene().buildIndex + 1;
        if (i < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(i);
        }*/
    }
    public void ChangePrevious()
    {
        string SceneName = SceneManager.GetActiveScene().name;
        switch (SceneName)
        {
            case "Step5":
                SceneManager.LoadScene("Step4");
                break;
            case "Step4":
                SceneManager.LoadScene("Step3");
                break;
            case "Step3":
                SceneManager.LoadScene("Step2");
                break;
            case "Step2":
                SceneManager.LoadScene("Step1");
                break;
            default:
                break;
        }
        /*int i = SceneManager.GetActiveScene().buildIndex - 1;
        if (i >= 0)
        {
            SceneManager.LoadScene(i);
        }*/
    }
}
