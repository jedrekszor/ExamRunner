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
    public enum item
    {
        Coffee,
        Drink,
        Notes,
        Stack,
        Tutorials,
        Clock,
        Exam,
        Games,
        Party,
        Phone
    }
    public item type;
    private PickUpText pickUpText;

    public AudioClip pickedUpSound;

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

        if (isBuff)
            offset *= -1;

        session = GameObject.Find("Session").GetComponent<Session>();
        pickUpText = GameObject.Find("PickUpText").GetComponent<PickUpText>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            AudioManager.PlaySound(pickedUpSound);
            session.Move(offset);
            //PICKUP SOUND but must be on player since the object is getting destroyed

            switch (type)
            {
                case item.Coffee:
                    pickUpText.SetText("coffee");
                    break;
                case item.Drink:
                    pickUpText.SetText("drink");
                    break;
                case item.Notes:
                    pickUpText.SetText("notes");
                    break;
                case item.Stack:
                    pickUpText.SetText("stack overflow");
                    break;
                case item.Tutorials:
                    pickUpText.SetText("hindi tutorials");
                    break;
                case item.Clock:
                    pickUpText.SetText("you're late");
                    break;
                case item.Exam:
                    pickUpText.SetText("failed exam");
                    break;
                case item.Games:
                    pickUpText.SetText("games");
                    break;
                case item.Party:
                    pickUpText.SetText("overpartied");
                    break;
                case item.Phone:
                    pickUpText.SetText("phone");
                    break;
            }
            
            
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * Controller.vel);
        
        if(transform.position.x < Camera.main.transform.position.x - 15)
            Destroy(gameObject);
    }
}
