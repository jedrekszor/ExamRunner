using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public AudioClip click; 
    
    public void Play()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 0;
    }
    
    public void OnClickSound()
    {
        AudioManager.PlaySound(click);
    }
}
