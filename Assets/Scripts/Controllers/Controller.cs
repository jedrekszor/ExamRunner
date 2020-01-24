using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private static int ects = 0;
    private static TextMeshProUGUI tm;
    public static float vel = 6;
    void Start()
    {
        tm = GameObject.Find("ECTSCounter").GetComponent<TextMeshProUGUI>();
    }

    public static void AddPoint()
    {
        ects++;
        if (ects == 30)
            Win();

        tm.text = ects + "/30";
    }

    public static void Win()
    {
        Debug.Log("U WIN");
        Debug.Break();
        //WIENER
    }

    public static void Lose()
    {
        Debug.Log("U LOSE");
        Debug.Break();
        //LOSER :'(
    }
}
