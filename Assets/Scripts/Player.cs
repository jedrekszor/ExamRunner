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
    private Animator animator;
    private float current;
    private float previous;
    [SerializeField] private float height;

    public AudioClip jumpSound;
    
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        session = GameObject.Find("Session").GetComponent<Session>();
        animator = GetComponent<Animator>();
        current = transform.position.x;
        previous = transform.position.x;
    }
    
    void Update()
    {
        previous = current;
        current = transform.position.x;
        if (current < previous)
            Paralax.canParalax = false;
        else
            Paralax.canParalax = true;
        
        
        
        Debug.Log(canJump);
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
        if (canJump && Controller.gameRunning)
        {
            AudioManager.PlaySound(jumpSound);
            animator.SetTrigger("Jump");
            rgbd.AddForce(new Vector2(0, height), ForceMode2D.Impulse);
            Instantiate(dust, transform.GetChild(0).position, Quaternion.identity);
            canJump = false;
//            Debug.Break();
        }
    }

//    private void OnCollisionEnter2D(Collision2D other)
//    {
//        if (other.gameObject.CompareTag("Block"))
//        {
////            Paralax.canParalax = false;
//            
//        }
//            
//    }
//
//    private void OnCollisionExit2D(Collision2D other)
//    {
//        if (other.gameObject.CompareTag("Block"))
//        {
////            Paralax.canParalax = true;
//            
//        }
//            
//    }
}
