using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    private int ects = 0;
    private TextMeshProUGUI tm;
    public static float vel = 7.5f;
    public static bool gameRunning;
    private GameObject startScreen;
    private GameObject loseScreen;
    private GameObject winScreen;
    private GameObject screens;
    public static bool firstTime = true;

    public AudioClip mainTheme;
    public AudioClip loseTheme;
    public AudioClip winTheme;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        screens = GameObject.Find("Screens");
        startScreen = GameObject.Find("StartScreen");
        loseScreen = GameObject.Find("LoseScreen");
        winScreen = GameObject.Find("WinScreen");
        tm = GameObject.Find("ECTSCounter").GetComponent<TextMeshProUGUI>();
        
        
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
        Time.timeScale = 0;
    }

    public void AddPoint()
    {
        if(tm == null)
            tm = GameObject.Find("ECTSCounter").GetComponent<TextMeshProUGUI>();
        
        ects++;
        if (ects == 30)
            Win();

        tm.text = ects + "/30";
    }

    public void Win()
    {
        if (winScreen == null)
        {
            screens = GameObject.Find("Screens");
            winScreen = screens.transform.GetChild(2).gameObject;
        }

        winScreen.SetActive(true);
        Time.timeScale = 0;
        AudioManager.PlaySoundtrack(winTheme);
        gameRunning = false;
    }

    public void Lose()
    {
        if(loseScreen == null)
        {
            screens = GameObject.Find("Screens");
            loseScreen = screens.transform.GetChild(1).gameObject;
        }
        
        loseScreen.SetActive(true);
        Time.timeScale = 0;
        AudioManager.PlaySoundtrack(loseTheme);
        gameRunning = false;
    }

    public void Play()
    {
        if(startScreen == null)
        {
            screens = GameObject.Find("Screens");
            startScreen = screens.transform.GetChild(0).gameObject;
        }
        
        startScreen.SetActive(false);
        Time.timeScale = 1;
        gameRunning = true;
        AudioManager.PlaySoundtrack(mainTheme);
    }

    

    public void Replay()
    {
        firstTime = false;
        gameRunning = true;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
        AudioManager.PlaySoundtrack(mainTheme);
        Destroy(gameObject);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        firstTime = true;
        gameRunning = false;
        Destroy(GameObject.Find("AudioManager"));
        Destroy(gameObject);
    }
}
