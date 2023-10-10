using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFaller : MonoBehaviour
{
    private bool isTriggered = false;
    private float timer = 0f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //gets rigidbody
        rb = GetComponent<Rigidbody>();
        //sets gravity as off initially
        rb.useGravity = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            Debug.Log("player entered");
        }
    }

    private void Update()
    {
        if (isTriggered)
        {
            //begin timer
            timer += Time.deltaTime;

            //check if 5 secs have passed
            if (timer >= 5f)
            {
                rb.useGravity = true; //enable gravity after 5 seconds
                isTriggered = false; //reset trigger
            }
        }
    }
}
    



