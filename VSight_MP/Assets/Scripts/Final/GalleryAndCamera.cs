using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryAndCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Gallery;
    public void ChangeScene()
    {
        GameObject.Find("ChooseFromGallery").SetActive(false);
        GameObject.Find("Camera").SetActive(false);
        Gallery.SetActive(true);
    }
}
