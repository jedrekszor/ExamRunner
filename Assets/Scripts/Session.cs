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
    private Controller controller;


    private void Start()
    {
        controller = GameObject.Find("!CONTROLLER").GetComponent<Controller>();
    }

    private void Update()
    {
        if (canGo)
        {
            transform.Translate(new Vector3(xDir, 0, 0) * Time.deltaTime * vel);
        }
        
        
        
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            controller.Lose();
        }
    }
}
