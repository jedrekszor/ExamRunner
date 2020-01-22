using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session : MonoBehaviour
{
    private bool canGo = false;
    private int xDir = 1;
    private int yDir = 1;
    public float vel;
    public float velY;
    private int cnt = 0;
    
    private void Update()
    {
        if (canGo)
        {
            transform.Translate(new Vector3(xDir, 0, 0) * Time.deltaTime * vel);
        }
        
        
        transform.Translate(new Vector3(0, yDir, 0) * Time.deltaTime * velY);
        if (cnt == 40)
        {
            cnt = 0;
            yDir *= -1;
        }

        cnt++;
    }

    public void Move(float dist)
    {
        xDir = 1;
        if (dist < 0)
            xDir = -1;

        canGo = true;
        StartCoroutine(Cooldown(dist));
    }

    private IEnumerator Cooldown(float dist)
    {
        yield return new WaitForSeconds(Mathf.Abs(dist));
        canGo = false;
    }
}
