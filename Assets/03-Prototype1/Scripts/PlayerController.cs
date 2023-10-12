using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    private Rigidbody rb;
    private int count;
    public GameObject YouWinText;
    public GameObject RestartButton;

    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed;
        rb.velocity = movement;

        //check if player falls
        if(transform.position.y <= 0)
        {
            //reload scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            if (count >= 9)
            {
                YouWinText.SetActive(true);
                RestartButton.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}