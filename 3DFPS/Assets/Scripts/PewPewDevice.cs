using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro; 

public class PewPewDevice : MonoBehaviour
{
    public GameObject Gun;
    public GameObject Bullet; 
    public Vector3 Aim; 
    public float ammo; 
   
   public Animator Rep; 

   public bool Ree = false; 
    public TextMeshProUGUI ACP;
    // Start is called before the first frame update
    void Start()
    {
        
        Rep = Gun.GetComponent<Animator>();
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
                StartCoroutine(stasrt()); 
            }
        }
        Rep.SetBool("Ree", Ree); 
    }
    IEnumerator stasrt()
    {
    Ree = true; 
   yield return new WaitForSeconds(1.6f);
    ammo = 6;
    ACP.text = ammo.ToString(); 
    Ree = false; 
    
        
    }




}
