using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffOnReload : MonoBehaviour
{
    void Start()
    {
        
        if (!Controller.firstTime)
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
            
    }
}
