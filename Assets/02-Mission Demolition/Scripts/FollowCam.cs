using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    //the static point of interest //a
    static public GameObject POI; 

    //the desired z pos of camera
    public float camZ;

    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

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

        //limit the x and y to minimum values
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);

        //interpolate from the current camera pos toward destination
        destination = Vector3.Lerp(transform.position, destination, easing);

        //sets destination.z to be camZ to keep camera far enough away
        destination.z = camZ;

        //set the camera to the destination
        transform.position = destination;

        //set the orthographicSize or the camera to keep Ground in view
        Camera.main.orthographicSize = destination.y + 10;
    }

}
