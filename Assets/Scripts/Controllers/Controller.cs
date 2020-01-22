using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private static int ects = 0;
    private static TextMeshProUGUI tm;
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
        //WIENER
    }

    public static void Lose()
    {
        //LOSER :'(
    }
}
