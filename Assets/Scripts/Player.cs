using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rgbd;
    public static bool canJump = true;

    [SerializeField] private float height;
    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void jump()
    {
        if (canJump)
        {
            rgbd.AddForce(new Vector2(0, height), ForceMode2D.Impulse);
            canJump = false;
        }
    }

    
}
