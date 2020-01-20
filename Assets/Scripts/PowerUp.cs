using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool isBuff;
    public int tier;
    private float offset;
    private Session session;
    
    void Start()
    {
        switch (tier)
        {
            case 1:
            {
                offset = 2;
            } break;
            case 2:
            {
                offset = 1.75f;
            } break;
            case 3:
            {
                offset = 1.5f;
            } break;
            case 4:
            {
                offset = 1.25f;
            } break;
            case 5:
            {
                offset = 1;
            } break;
        }

        if (!isBuff)
            offset *= -1;

        session = GameObject.Find("Session").GetComponent<Session>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            session.Move(offset);
        }
    }

    private void Update()
    {
        if(transform.position.x < -15)
            Destroy(gameObject);
    }
}
