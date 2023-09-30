using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    //the static point of interest //a
    static public GameObject POI; 

    //the desired z pos of camera
    public float camZ;

     void Awake()
    {
        camZ = this.transform.position.z;
    }

     void FixedUpdate()
    {
        //return if there is no POI //b
        if (POI == null) return;

        //get the position of the POI
        Vector3 destination = POI.transform.position;
        //sets destination.z to be camZ to keep camera far enough away
        destination.z = camZ;
        //set the camera to the destination
        transform.position = destination;
    }

}
