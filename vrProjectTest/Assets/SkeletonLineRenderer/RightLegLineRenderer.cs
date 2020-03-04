using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLegLineRenderer : MonoBehaviour {

    LineRenderer lineRendererRightLeg;

    GameObject HipRight;
    GameObject KneeRight;
    GameObject AnkleRight;
    GameObject FootRight;

    void Start () {
        lineRendererRightLeg = gameObject.AddComponent<LineRenderer>();
        lineRendererRightLeg.positionCount = 4;
        lineRendererRightLeg.material.color = Color.red;
        lineRendererRightLeg.widthMultiplier = 2.0f;

        HipRight = GameObject.Find("HipRight");
        KneeRight = GameObject.Find("KneeRight");
        AnkleRight = GameObject.Find("AnkleRight");
        FootRight = GameObject.Find("FootRight");
    }
	
	void Update () {
        lineRendererRightLeg.SetPosition(0, HipRight.transform.position);
        lineRendererRightLeg.SetPosition(1, KneeRight.transform.position);
        lineRendererRightLeg.SetPosition(2, AnkleRight.transform.position);
        lineRendererRightLeg.SetPosition(3, FootRight.transform.position);
    }
}
