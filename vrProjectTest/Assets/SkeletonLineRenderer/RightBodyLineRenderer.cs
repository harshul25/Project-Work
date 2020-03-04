using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBodyLineRenderer : MonoBehaviour {

    LineRenderer lineRendererRightBody;

    GameObject ShoulderCenter;
    GameObject ShoulderRight;
    GameObject Spine;
    GameObject HipRight;
    GameObject HipCenter;


    void Start () {
        lineRendererRightBody = gameObject.AddComponent<LineRenderer>();
        lineRendererRightBody.positionCount = 5;
        lineRendererRightBody.material.color = Color.blue;
        lineRendererRightBody.widthMultiplier = 2.0f;

        ShoulderCenter = GameObject.Find("ShoulderCenter");
        ShoulderRight = GameObject.Find("ShoulderRight");
        Spine = GameObject.Find("Spine");
        HipRight = GameObject.Find("HipRight");
        HipCenter = GameObject.Find("HipCenter");
    }

	void Update () {
        lineRendererRightBody.SetPosition(0, ShoulderCenter.transform.position);
        lineRendererRightBody.SetPosition(1, ShoulderRight.transform.position);
        lineRendererRightBody.SetPosition(2, Spine.transform.position);
        lineRendererRightBody.SetPosition(3, HipRight.transform.position);
        lineRendererRightBody.SetPosition(4, HipCenter.transform.position);
    }
}
