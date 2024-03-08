using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PewPewDevice : MonoBehaviour
{
    public GameObject Bullet; 
    public Vector3 Aim; 
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
          //  Vector3 gunPosition = transform.position; 
          Vector3 Aim = transform.position; 
         Quaternion gunRotation = transform.rotation;
         Instantiate(Bullet, Aim, gunRotation); 
         //   Instantiate(Bullet, gunPosition, gunRotation); 
        }
    }


}
