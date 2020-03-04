using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralBodyLineRenderer : MonoBehaviour {

    LineRenderer lineRendererCenterBody;

    GameObject Head;
    GameObject ShoulderCenter;
    GameObject Spine;
    GameObject HipCenter;
    
    void Start () {
        lineRendererCenterBody = gameObject.AddComponent<LineRenderer>() as LineRenderer;
        lineRendererCenterBody.positionCount = 4;
        lineRendererCenterBody.material.color = Color.blue;
        lineRendererCenterBody.widthMultiplier = 2.0f;

        Head = GameObject.Find("Head");
        ShoulderCenter = GameObject.Find("ShoulderCenter");
        Spine = GameObject.Find("Spine");
        HipCenter = GameObject.Find("HipCenter");
    }
	
	// Update is called once per frame
	void Update () {
        //lineRendererCenterBody.SetPosition(0, Head.transform.position);
        lineRendererCenterBody.SetPosition(0, ShoulderCenter.transform.position);
        lineRendererCenterBody.SetPosition(1, ShoulderCenter.transform.position);
        lineRendererCenterBody.SetPosition(2, Spine.transform.position);
        lineRendererCenterBody.SetPosition(3, HipCenter.transform.position);
    }
}
