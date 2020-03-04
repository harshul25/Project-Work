using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class CameraAnimation  : MonoBehaviour
{

    GameObject Camera;
    GameObject Head;

    // Use this for initialization
    void Start()
    {
        Camera =  GameObject.Find("Camera");
        Head = GameObject.Find("Head");
    }

    // Update is called once per frame
    void Update()
    {
        Camera.transform.position = Head.transform.position;
    }
}
