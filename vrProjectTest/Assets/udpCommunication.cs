using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;
using System.Threading;
using Assets;
using Newtonsoft.Json;

public class udpCommunication : MonoBehaviour {

    private const int listenPort = 11000;
    static bool done = false;
    static UdpClient listener = new UdpClient(listenPort);
    static IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
    Thread udpThread;

    GameObject World;
    private float xWorldBias = 70;
    private float yWorldBias = 0;
    private float zWorldBias = -100;


    static SkeletonObject skeletonObject;

    GameObject Head;
    GameObject ShoulderCenter;
    GameObject ShoulderLeft;
    GameObject ShoulderRight;
    GameObject Spine;
    GameObject HipCenter;
    GameObject HipLeft;
    GameObject HipRight;

    GameObject ElbowLeft;
    GameObject WristLeft;
    GameObject HandLeft;

    GameObject ElbowRight;
    GameObject WristRight;
    GameObject HandRight;

    GameObject KneeLeft;
    GameObject AnkleLeft;
    GameObject FootLeft;

    GameObject KneeRight;
    GameObject AnkleRight;
    GameObject FootRight;

    GameObject Camera;
    GameObject Skeleton;

    private float xMultiplier = 60.0f;
    private float yMultiplier = 60.0f;
    private float zMultiplier = 60.0f;

    private float xBias = 40f;
    private float yBias = 40f;
    private float zBias = -40f;

    void Start () {

        World = GameObject.Find("World");
        Camera = GameObject.Find("Camera");
        Skeleton = GameObject.Find("Skeleton");


        skeletonObject = new SkeletonObject();

        Head = GameObject.Find("Head");
        Head.GetComponent<Renderer>().material.color = Color.blue;
        ShoulderCenter = GameObject.Find("ShoulderCenter");
        ShoulderCenter.GetComponent<Renderer>().material.color = Color.blue;
        ShoulderLeft = GameObject.Find("ShoulderLeft");
        ShoulderLeft.GetComponent<Renderer>().material.color = Color.green;
        ShoulderRight = GameObject.Find("ShoulderRight");
        ShoulderRight.GetComponent<Renderer>().material.color = Color.green;
        Spine = GameObject.Find("Spine");
        Spine.GetComponent<Renderer>().material.color = Color.blue;
        HipCenter = GameObject.Find("HipCenter");
        HipCenter.GetComponent<Renderer>().material.color = Color.blue;
        HipLeft = GameObject.Find("HipLeft");
        HipLeft.GetComponent<Renderer>().material.color = Color.red;
        HipRight = GameObject.Find("HipRight");
        HipRight.GetComponent<Renderer>().material.color = Color.red;

        ElbowLeft = GameObject.Find("ElbowLeft");
        ElbowLeft.GetComponent<Renderer>().material.color = Color.green;
        WristLeft = GameObject.Find("WristLeft");
        WristLeft.GetComponent<Renderer>().material.color = Color.green;
        HandLeft = GameObject.Find("HandLeft");
        HandLeft.GetComponent<Renderer>().material.color = Color.green;

        ElbowRight = GameObject.Find("ElbowRight");
        ElbowRight.GetComponent<Renderer>().material.color = Color.green;
        WristRight = GameObject.Find("WristRight");
        WristRight.GetComponent<Renderer>().material.color = Color.green;
        HandRight = GameObject.Find("HandRight");
        HandRight.GetComponent<Renderer>().material.color = Color.green;

        KneeLeft = GameObject.Find("KneeLeft");
        KneeLeft.GetComponent<Renderer>().material.color = Color.red;
        AnkleLeft = GameObject.Find("AnkleLeft");
        AnkleLeft.GetComponent<Renderer>().material.color = Color.red;
        FootLeft = GameObject.Find("FootLeft");
        FootLeft.GetComponent<Renderer>().material.color = Color.red;

        KneeRight = GameObject.Find("KneeRight");
        KneeRight.GetComponent<Renderer>().material.color = Color.red;
        AnkleRight = GameObject.Find("AnkleRight");
        AnkleRight.GetComponent<Renderer>().material.color = Color.red;
        FootRight = GameObject.Find("FootRight");
        FootRight.GetComponent<Renderer>().material.color = Color.red;

        udpThread = new Thread(udpCommunication.startUDP);
        udpThread.Start();
	}

    void Update() {

        xBias = Camera.transform.position.x - skeletonObject.Head.x * xMultiplier;
        yBias = Camera.transform.position.y - skeletonObject.Head.y * xMultiplier;
        zBias = Camera.transform.position.z - skeletonObject.Head.z * xMultiplier;

        float lowestPoint = Math.Min(skeletonObject.FootLeft.y, skeletonObject.FootRight.y);
        //yMultiplier = Camera.transform.position.y / (Camera.transform.position.y - lowestPoint);
        //xMultiplier = yMultiplier;
        //xMultiplier = yMultiplier;

        Vector3 worldVector = new Vector3();
        worldVector.Set(
            skeletonObject.Head.x * xMultiplier * -1 + xWorldBias,
            yWorldBias,
            skeletonObject.Head.z * zMultiplier + zWorldBias);

        World.transform.position = worldVector;

        createSkeleton();

        //transform.Rotate(0, 180, 0, Space.World);
    }

    private void OnApplicationQuit()
    {
        done = true;
    }

    static void startUDP()
    {
        byte[] receive_byte_array;
        string received_data;

        while (!done) {
            try
            {
                receive_byte_array = listener.Receive(ref groupEP);
                received_data = Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length);
                skeletonObject = JsonConvert.DeserializeObject<SkeletonObject>(received_data);
            } catch (Exception ex)
            {
                Debug.Log("Exception: " + ex.Message);
                done = true;
            }
        }

        listener.Close();
    }

    Vector3 generateVector(JointObject joint)
    {
        Vector3 vector = new Vector3();
        vector.Set(
            joint.x * xMultiplier + xBias, 
            joint.y * yMultiplier + yBias, 
            (joint.z * zMultiplier + zBias) * -1);

        return vector;
    }

    void createSkeleton()
    {
        Head.transform.position = generateVector(skeletonObject.Head);
        ShoulderCenter.transform.position = generateVector(skeletonObject.ShoulderCenter);
        ShoulderLeft.transform.position = generateVector(skeletonObject.ShoulderLeft);
        ShoulderRight.transform.position = generateVector(skeletonObject.ShoulderRight);
        Spine.transform.position = generateVector(skeletonObject.Spine);
        HipCenter.transform.position = generateVector(skeletonObject.HipCenter);
        HipLeft.transform.position = generateVector(skeletonObject.HipLeft);
        HipRight.transform.position = generateVector(skeletonObject.HipRight);

        ElbowLeft.transform.position = generateVector(skeletonObject.ElbowLeft);
        WristLeft.transform.position = generateVector(skeletonObject.WristLeft);
        HandLeft.transform.position = generateVector(skeletonObject.HandLeft);

        ElbowRight.transform.position = generateVector(skeletonObject.ElbowRight);
        WristRight.transform.position = generateVector(skeletonObject.WristRight);
        HandRight.transform.position = generateVector(skeletonObject.HandRight);

        KneeLeft.transform.position = generateVector(skeletonObject.KneeLeft);
        AnkleLeft.transform.position = generateVector(skeletonObject.AnkleLeft);
        FootLeft.transform.position = generateVector(skeletonObject.FootLeft);

        KneeRight.transform.position = generateVector(skeletonObject.KneeRight);
        AnkleRight.transform.position = generateVector(skeletonObject.AnkleRight);
        FootRight.transform.position = generateVector(skeletonObject.FootRight);
    }
}
