using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]

    public Text scoreGT;
    // Start is called before the first frame update
    void Start()
    {
        //find reference to scorecounter game object
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //get text component of that gameobject
        scoreGT = scoreGO.GetComponent<Text>();
        //set starting number to 0
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        //get current location of mouse on screen
        Vector3 mousePos2D = Input.mousePosition;

        //cameras z pos sets how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z;

        //convert mouse from 2d screen space into 3d game space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //move the x pos of basket to the x pos of mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

   void OnCollisionEnter(Collision coll)
    {
        //find out what hit the basekt
        GameObject collidedWith = coll.gameObject;

        if(collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();

            if(score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
