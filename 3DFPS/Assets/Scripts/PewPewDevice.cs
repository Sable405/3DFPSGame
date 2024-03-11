using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro; 

public class PewPewDevice : MonoBehaviour
{
    public GameObject Bullet; 
    public Vector3 Aim; 
    public float ammo; 
   
   private Animation Rep; 
   public bool Re; 
    public TextMeshProUGUI ACP;
    // Start is called before the first frame update
    void Start()
    {
        Rep = gameObject.GetComponent<Animation>();
        ammo = 6;
        ACP.text = ammo.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammo > 0)
        {
            ammo = ammo - 1; 
            ACP.text = ammo.ToString(); 
          //  Vector3 gunPosition = transform.position; 
          Vector3 Aim = transform.position; 
         Quaternion gunRotation = transform.rotation;
         Instantiate(Bullet, Aim, gunRotation); 
         //   Instantiate(Bullet, gunPosition, gunRotation); 
        }
        if (ammo <= 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Re = true; 
                ammo = 6;
                ACP.text = ammo.ToString(); 

            }
        }
    }


}
