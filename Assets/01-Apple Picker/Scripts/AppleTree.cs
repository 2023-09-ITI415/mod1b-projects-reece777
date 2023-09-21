using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]

    public GameObject applePrefab;
    //tree speed
    public float speed = 1f;
    //distance tree turns around
    public float leftAndRightEdge = 10f;
    //Chance tree will change direction
    public float chanceToChangeDirection;
    //Rate apples will drop
    public float secondsBetweenAppleDrop;


    // Start is called before the first frame update
    void Start()
    {
        //Dropping apples every second

        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);

        apple.transform.position = transform.position;

        Invoke("DropApple", secondsBetweenAppleDrop);
    }
    // Update is called once per frame
    void Update()
    {
        //basic movement

        Vector3 pos = transform.position;

        pos.x += speed * Time.deltaTime;

        transform.position = pos;

        //Changing direction

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //move left
        } 
    }
       
        void FixedUpdate() 
    {   //changes direction randomly
        if (Random.value < chanceToChangeDirection)
        {
            speed *= -1;
        }
    }
    }

