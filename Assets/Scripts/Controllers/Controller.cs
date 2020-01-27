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
    public static bool gameRunning = false;
    private GameObject startScreen;
    private GameObject loseScreen;
    private GameObject winScreen;
    public static bool firstTime = true;

    public AudioClip mainTheme;
    public AudioClip loseTheme;
    public AudioClip winTheme;
    public AudioClip menuTheme;
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        startScreen = GameObject.Find("StartScreen");
        loseScreen = GameObject.Find("LoseScreen");
        winScreen = GameObject.Find("WinScreen");
        tm = GameObject.Find("ECTSCounter").GetComponent<TextMeshProUGUI>();
        
        
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
        Time.timeScale = 0;
    }

    private void Update()
    {
        throw new NotImplementedException();
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
        winScreen.SetActive(true);
        Time.timeScale = 0;
        AudioManager.PlaySoundtrack(winTheme);
        gameRunning = false;
    }

    public void Lose()
    {
        loseScreen.SetActive(true);
        Time.timeScale = 0;
        AudioManager.PlaySoundtrack(loseTheme);
        gameRunning = false;
    }

    public void Play()
    {
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
        ects = 0;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        AudioManager.PlaySoundtrack(mainTheme);
        firstTime = true;
        gameRunning = false;
    }
}
