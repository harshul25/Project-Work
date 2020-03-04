using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArmLineRenderer : MonoBehaviour {

    LineRenderer lineRendererLeftArm;

    GameObject ShoulderLeft;
    GameObject ElbowLeft;
    GameObject WristLeft;
    GameObject HandLeft;

    void Start () {
        lineRendererLeftArm = gameObject.AddComponent<LineRenderer>();
        lineRendererLeftArm.positionCount = 4;
        lineRendererLeftArm.material.color = Color.green;
        lineRendererLeftArm.widthMultiplier = 2.0f;

        ShoulderLeft = GameObject.Find("ShoulderLeft");
        ElbowLeft = GameObject.Find("ElbowLeft");
        WristLeft = GameObject.Find("WristLeft");
        HandLeft = GameObject.Find("HandLeft");
    }
	
	void Update () {
        lineRendererLeftArm.SetPosition(0, ShoulderLeft.transform.position);
        lineRendererLeftArm.SetPosition(1, ElbowLeft.transform.position);
        lineRendererLeftArm.SetPosition(2, WristLeft.transform.position);
        lineRendererLeftArm.SetPosition(3, HandLeft.transform.position);
    }
}
