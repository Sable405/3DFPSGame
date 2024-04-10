using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro; 


public class PewPewDevice : MonoBehaviour
{
    public AudioClip Shooting; 
    public AudioClip RElad;
    public AudioSource _Sound;
    public GameObject Gun;
    public GameObject Bullet; 
    public Vector3 Aim; 
    public float ammo; 
   
   public Animator Rep; 

   public bool Ree = false; 
    public TextMeshProUGUI ACP;

    public TextMeshProUGUI Kill;
        public float Tee; 
  

    // Start is called before the first frame update
    void Start()
    {
        _Sound = GetComponent<AudioSource>();
        Ree = false;
        Rep = Gun.GetComponent<Animator>();
        ammo = 6;
        ACP.text = ammo.ToString(); 
        Kill.text = Tee.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammo > 0)
        {
         StartCoroutine(WaitGunTime());
         _Sound.PlayOneShot(Shooting, 1.0f);
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
    _Sound.PlayOneShot(RElad, 1.0f);
    Ree = true; 
   yield return new WaitForSeconds(1.6f);
    ammo = 6;
    ACP.text = ammo.ToString(); 
    Ree = false; 
    
        
    }
    IEnumerator WaitGunTime()
    {
        
            ammo = ammo - 1; 
            ACP.text = ammo.ToString(); 
          Vector3 Aim = transform.position; 
         Quaternion gunRotation = transform.rotation;
         Instantiate(Bullet, Aim, gunRotation);
          yield return new WaitForSeconds(0.2f);
    }

    public void Kilt() 
    {
        Tee = Tee + 1;
        Kill.text = Tee.ToString();
    }








}
