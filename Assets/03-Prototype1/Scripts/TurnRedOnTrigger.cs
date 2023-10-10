using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRedOnTrigger : MonoBehaviour
{
    private bool isDefTriggered = false;
    private Renderer objectRenderer;
    public Material redMaterial;
    public Material greenMaterial;


    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        objectRenderer.material = greenMaterial;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !isDefTriggered)
        {
            isDefTriggered = true;
            //change material to red material
            objectRenderer.material = redMaterial;
        }
    }
}
