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

    //restart button reloads scene
    public void Restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Time.timeScale = 0;
        

        
    }

}
