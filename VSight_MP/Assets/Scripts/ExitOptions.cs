using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitOptions : MonoBehaviour
{
    public GameObject buttons;
    public GameObject gallery;
    public GameObject options;
    // Start is called before the first frame update
    void Start()
    {
        //buttons = GameObject.Find("Buttons");
        //gallery = GameObject.Find("Gallery");
        //options = GameObject.Find("Options");
        buttons.SetActive(false);
        gallery.SetActive(false);
        options.SetActive(true);
    }

    public void ExitTheOptions()
    {
        buttons.SetActive(true);
        gallery.SetActive(true);
        options.SetActive(false);
    }
    public void ReturnTheOptions()
    {
        buttons.SetActive(false);
        gallery.SetActive(false);
        options.SetActive(true);
    }
}
