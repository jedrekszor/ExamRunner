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
    private GameObject almostWinScreen;
    private GameObject winScreen;
    private GameObject pauseScreen;
    private GameObject screens;
    private GameObject stats;
    public static bool firstTime = true;
    public bool canPause = false;
    public float time;

    public AudioClip mainTheme;
    public AudioClip loseTheme;
    public AudioClip winTheme;
    public AudioClip yeet;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        screens = GameObject.Find("Screens");
        startScreen = GameObject.Find("StartScreen");
        loseScreen = GameObject.Find("LoseScreen");
        winScreen = GameObject.Find("WinScreen");
        almostWinScreen = GameObject.Find("AlmostWinScreen");
        pauseScreen = GameObject.Find("PauseScreen");
        stats = GameObject.Find("Stats");
        tm = GameObject.Find("ECTSCounter").GetComponent<TextMeshProUGUI>();
        
        if(startScreen == null)
        {
            screens = GameObject.Find("Screens");
            startScreen = screens.transform.GetChild(0).gameObject;
        }
        loseScreen.SetActive(false);
        almostWinScreen.SetActive(false);
        winScreen.SetActive(false);
        pauseScreen.SetActive(false);
        stats.SetActive(false);
        Time.timeScale = 0;

        ects = 29;    //DEBUG
        tm.text = ects + "/30";
        
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
            winScreen = screens.transform.GetChild(3).gameObject;
        }

        winScreen.SetActive(true);
        Time.timeScale = 0;
        AudioManager.PlaySoundtrack(winTheme);
        gameRunning = false;
        canPause = false;
        SetStats(true);
    }

    private void Update()
    {
        if(gameRunning)
            time += Time.deltaTime;
    }

    public void Lose()
    {
        if (ects < 18)
        {
            if(loseScreen == null)
            {
                screens = GameObject.Find("Screens");
                loseScreen = screens.transform.GetChild(1).gameObject;
            }
            loseScreen.SetActive(true);
        }
        else
        {
            if(almostWinScreen == null)
            {
                screens = GameObject.Find("Screens");
                almostWinScreen = screens.transform.GetChild(2).gameObject;
            }
            almostWinScreen.SetActive(true);
        }
        
        SetStats(false);
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
            pauseScreen = screens.transform.GetChild(4).gameObject;
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
            pauseScreen = screens.transform.GetChild(4).gameObject;
        }
        Time.timeScale = 1;
        gameRunning = true;
        pauseScreen.SetActive(false);
    }

    private void SetStats(bool win)
    {
        if (stats == null)
        {
            stats = GameObject.Find("MainCanvas").transform.GetChild(4).gameObject;
        }

        stats.SetActive(true);
        stats.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = ects + "/30";
        stats.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "Your time: " + time.ToString("F2");
        if ((time < PlayerPrefs.GetFloat("HighScore") || PlayerPrefs.GetFloat("HighScore") == 0f) && win)
        {
            PlayerPrefs.SetFloat("HighScore", time);
            stats.transform.GetChild(3).gameObject.SetActive(true);
            AudioManager.PlaySound(yeet);
        }
        stats.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = "High score: " + PlayerPrefs.GetFloat("HighScore").ToString("F2");

        
    }
}
