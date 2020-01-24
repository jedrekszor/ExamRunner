using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpText : MonoBehaviour
{
    private TextMeshProUGUI tm;
    
    private void Start()
    {
        tm = GetComponent<TextMeshProUGUI>();
    }

    public void SetText(String text)
    {
        tm.text = text;
        StartCoroutine(dismiss(text));
    }

    private IEnumerator dismiss(String text)
    {
        yield return new WaitForSeconds(3);
        if(tm.text == text)
            tm.text = "";
    }
}
