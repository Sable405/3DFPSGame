using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnStartClick()
    {
        SceneManager.LoadScene(0);
    }

     public void OnQuitSClick()
    {
        SceneManager.LoadScene(2);
    }

    public void OnPClick()
    {
        SceneManager.LoadScene(4);
    }
 public void Cont()
    {
        SceneManager.LoadScene(1);
    }


}
