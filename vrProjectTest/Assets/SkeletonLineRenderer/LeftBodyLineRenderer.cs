using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBodyLineRenderer : MonoBehaviour {

    LineRenderer lineRendererLeftBody;

    GameObject ShoulderCenter;
    GameObject ShoulderLeft;
    GameObject Spine;
    GameObject HipLeft;
    GameObject HipCenter;

    void Start () {
        lineRendererLeftBody = gameObject.AddComponent<LineRenderer>() as LineRenderer;
        lineRendererLeftBody.positionCount = 5;
        lineRendererLeftBody.material.color = Color.blue;
        lineRendererLeftBody.widthMultiplier = 2.0f;

        ShoulderCenter = GameObject.Find("ShoulderCenter");
        ShoulderLeft = GameObject.Find("ShoulderLeft");
        Spine = GameObject.Find("Spine");
        HipLeft = GameObject.Find("HipLeft");
        HipCenter = GameObject.Find("HipCenter");
    }
	
	void Update () {
        lineRendererLeftBody.SetPosition(0, ShoulderCenter.transform.position);
        lineRendererLeftBody.SetPosition(1, ShoulderLeft.transform.position);
        lineRendererLeftBody.SetPosition(2, Spine.transform.position);
        lineRendererLeftBody.SetPosition(3, HipLeft.transform.position);
        lineRendererLeftBody.SetPosition(4, HipCenter.transform.position);
    }
}
