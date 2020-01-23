using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rgbd;
    public static bool canJump = true;
    private Session session;
    public GameObject dust;

    [SerializeField] private float height;
    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        session = GameObject.Find("Session").GetComponent<Session>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            jump();
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
            session.Move(-1);
        
        if(Input.GetKeyDown(KeyCode.RightArrow))
            session.Move(1);
    }

    public void jump()
    {
        if (canJump)
        {
            rgbd.AddForce(new Vector2(0, height), ForceMode2D.Impulse);
            Instantiate(dust, transform.GetChild(0).position, Quaternion.identity);
            canJump = false;
//            Debug.Break();
        }
    }

    
}
