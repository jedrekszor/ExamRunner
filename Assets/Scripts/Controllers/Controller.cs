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
    public static float vel = 6f;
    public static bool gameRunning;
    private GameObject startScreen;
    private GameObject loseScreen;
    private GameObject winScreen;
    private GameObject pauseScreen;
    private GameObject screens;
    public static bool firstTime = true;
    public bool canPause = false;

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
        pauseScreen = GameObject.Find("PauseScreen");
        tm = GameObject.Find("ECTSCounter").GetComponent<TextMeshProUGUI>();
        
        if(startScreen == null)
        {
            screens = GameObject.Find("Screens");
            startScreen = screens.transform.GetChild(0).gameObject;
        }
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
        pauseScreen.SetActive(false);
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
        canPause = false;
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
        canPause = false;
    }

    public void Play()
    {
        startScreen.SetActive(false);
        Time.timeScale = 1;
        gameRunning = true;
        AudioManager.PlaySoundtrack(mainTheme);
        canPause = true;
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

    public void Pause()
    {
        if (pauseScreen == null)
        {
            screens = GameObject.Find("Screens");
            pauseScreen = screens.transform.GetChild(3).gameObject;
        }
        Time.timeScale = 0;
        gameRunning = false;
        pauseScreen.SetActive(true);
    }

    public void Unpause()
    {
        if (pauseScreen == null)
        {
            screens = GameObject.Find("Screens");
            pauseScreen = screens.transform.GetChild(3).gameObject;
        }
        Time.timeScale = 1;
        gameRunning = true;
        pauseScreen.SetActive(false);
    }
}
