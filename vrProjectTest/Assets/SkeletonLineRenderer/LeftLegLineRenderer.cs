using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftLegLineRenderer : MonoBehaviour {

    LineRenderer lineRendererLeftLeg;

    GameObject HipLeft;
    GameObject KneeLeft;
    GameObject AnkleLeft;
    GameObject FootLeft;

    void Start () { 
        lineRendererLeftLeg = gameObject.AddComponent<LineRenderer>();
        lineRendererLeftLeg.positionCount = 4;
        lineRendererLeftLeg.material.color = Color.red;
        lineRendererLeftLeg.widthMultiplier = 2.0f;

        HipLeft = GameObject.Find("HipLeft");
        KneeLeft = GameObject.Find("KneeLeft");
        AnkleLeft = GameObject.Find("AnkleLeft");
        FootLeft = GameObject.Find("FootLeft");
    }
	
	// Update is called once per frame
	void Update () {
        lineRendererLeftLeg.SetPosition(0, HipLeft.transform.position);
        lineRendererLeftLeg.SetPosition(1, KneeLeft.transform.position);
        lineRendererLeftLeg.SetPosition(2, AnkleLeft.transform.position);
        lineRendererLeftLeg.SetPosition(3, FootLeft.transform.position);
    }
}
