using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    private static int ects = 0;
    private static TextMeshProUGUI tm;
    public static float vel = 6;
    public static bool gameRunning = false;
    private GameObject startScreen;
    private static GameObject loseScreen;
    public static bool firstTime = true;

    public AudioClip mainTheme;
    public AudioClip loseTheme;
    public AudioClip winTheme;
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        startScreen = GameObject.Find("StartScreen");
        loseScreen = GameObject.Find("LoseScreen");
        loseScreen.SetActive(false);
        tm = GameObject.Find("ECTSCounter").GetComponent<TextMeshProUGUI>();
        Time.timeScale = 0;
    }

    public void AddPoint()
    {
        ects++;
        if (ects == 30)
            Win();

        tm.text = ects + "/30";
    }

    public void Win()
    {
        Debug.Log("U WIN");
        Debug.Break();
        AudioManager.PlaySoundtrack(winTheme);
    }

    public void Lose()
    {
        loseScreen.SetActive(true);
        Time.timeScale = 0;
        AudioManager.PlaySoundtrack(loseTheme);
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
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
        AudioManager.PlaySoundtrack(mainTheme);
    }
}
