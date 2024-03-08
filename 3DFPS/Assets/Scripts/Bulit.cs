using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulit : MonoBehaviour
{
   
    public float speed = 10;
    public float lifespan = 10f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;

        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
