using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clickTask : MonoBehaviour
{
    public void ClickChange()
    {
        SceneManager.LoadScene(2);
    }
}
