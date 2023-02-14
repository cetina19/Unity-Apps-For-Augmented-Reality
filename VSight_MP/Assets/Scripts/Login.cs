using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    [SerializeField]
    public InputField Accountname;

    [SerializeField]
    public InputField Username;

    [SerializeField]
    public InputField Password;

    public void CheckLogin()
    {
        string accountname = Accountname.text.Trim().ToLower();
        string username = Username.text.Trim().ToLower();
        string password = Password.text;

        if(username == "" || password == "" || accountname == "")
        {
            Debug.Log("Something is not filled out!!!");
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}
