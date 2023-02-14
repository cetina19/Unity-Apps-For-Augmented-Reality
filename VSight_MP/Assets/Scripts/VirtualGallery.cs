using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UI.Raw;

public class VirtualGallery : MonoBehaviour
{
    public Texture[] gallery = new Texture2D[5];
    public RawImage displayImage;
    public int i = 0; //Will control where in the array you are

    void Start()
    {
        displayImage.texture = gallery[i];
        //displayImage = GameObject.Find("Gallery").GetComponent<RawImage>;
    }
    public void BtnNext()
    {
        if (i + 1 < gallery.Length)
            i++;
        else
            i = 0;
    }

    public void BtnPrev()
    {
        if (i - 1 >= 0)
            i--;
        else
            i=gallery.Length-1;
    }

    void Update()
    {
        displayImage.texture = gallery[i];
        //displayImage.Texture2D;
    }
}
