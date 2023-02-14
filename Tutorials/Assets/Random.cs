using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random : MonoBehaviour
{
    public List<int> ages = new List<int>();
    public List<GameObject> objects = new List<GameObject>();

    public Renderer renderer1, renderer2;

    [SerializeField] public Vector3 transVector;
    public Vector3 posVector = new Vector3(0,0,0);

    public float r;
    public float g;
    public float b;
    public float a;

    void Start(){
        objects.Add(GameObject.Find("CubeObject1"));
        //renderer1 = UnityEngine.GameObject.FindGameObjectss
        
    }

    void Update(){
        if(objects[0]!=null){
            renderer1 = objects[0].GetComponent<Renderer>();
            renderer2 = objects[0].GetComponent<Renderer>();
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            ages.Add(UnityEngine.Random.Range(1,100));
        }

        if(Input.GetKeyDown(KeyCode.R) && ages.Count!=0){
            ages.Remove(ages[UnityEngine.Random.Range(0,ages.Count)]);
        }

        if(Input.GetKeyDown(KeyCode.C)){
            r = UnityEngine.Random.Range(0f,1f);
            g = UnityEngine.Random.Range(0f,1f);
            b = UnityEngine.Random.Range(0f,1f);
            a = UnityEngine.Random.Range(0f,1f);
            Color color1 = new Color(r,g,b,a);
            renderer1.material.color = color1;
        }

        if(Input.GetKeyDown(KeyCode.U)){
            //currVector = Vector3.Lerp(90,0,0);
            renderer2.transform.Rotate(transVector);
        }

        if(Input.GetKeyDown(KeyCode.T)){
            posVector.z +=3; 
            posVector.z = posVector.z % 12;
            renderer2.transform.position = posVector;
        }
    }
}
