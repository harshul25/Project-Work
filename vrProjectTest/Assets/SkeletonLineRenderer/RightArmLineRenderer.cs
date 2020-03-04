using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArmLineRenderer : MonoBehaviour {

    LineRenderer lineRendererRightArm;

    GameObject ShoulderRight;
    GameObject ElbowRight;
    GameObject WristRight;
    GameObject HandRight;

    void Start () {
        lineRendererRightArm = gameObject.AddComponent<LineRenderer>();
        lineRendererRightArm.positionCount = 4;
        lineRendererRightArm.material.color = Color.green;
        lineRendererRightArm.widthMultiplier = 2.0f;

        ShoulderRight = GameObject.Find("ShoulderRight");
        ElbowRight = GameObject.Find("ElbowRight");
        WristRight = GameObject.Find("WristRight");
        HandRight = GameObject.Find("HandRight");
    }
	
	// Update is called once per frame
	void Update () {
        lineRendererRightArm.SetPosition(0, ShoulderRight.transform.position);
        lineRendererRightArm.SetPosition(1, ElbowRight.transform.position);
        lineRendererRightArm.SetPosition(2, WristRight.transform.position);
        lineRendererRightArm.SetPosition(3, HandRight.transform.position);
    }
}
