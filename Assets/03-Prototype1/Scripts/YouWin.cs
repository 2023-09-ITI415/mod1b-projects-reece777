using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour

{
    public GameObject YouWinText;
    public GameObject RestartButton;
    public GameObject[] Platforms; //stores all the platforms

    // Start is called before the first frame update
    void Start()
    {
        //sets winning text and restart button to false
        YouWinText.SetActive(false);
        RestartButton.SetActive(false);
    }

    //method to check if all playforms are destroyed
    private bool AllPlatformsDestroyed()
    {
        foreach(GameObject platform in Platforms)
        {
            if(platform != null)
            {
                return false; //A platform is still active
            }
        }

        return true; //all platforms are gone. 
    }
    // Update is called once per frame
    void Update()
    {
        if (AllPlatformsDestroyed())
        {
            //pauses the game and shows text and restart button
            YouWinText.SetActive(true);
            RestartButton.SetActive(true);
            Time.timeScale = 0;
        }

        
    }

    //restart button reloads scene
    public void Restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
