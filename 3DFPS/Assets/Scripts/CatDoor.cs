using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class CatDoor : MonoBehaviour
{
    public int sceneNumber;
    public bool inTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && inTrigger)
        {
            SceneManager.LoadScene(1);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //SceneManager.LoadScene(sceneNumber);
            inTrigger = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

}
