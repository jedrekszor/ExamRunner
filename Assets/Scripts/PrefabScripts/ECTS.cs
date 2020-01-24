using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECTS : MonoBehaviour
{
    private Transform flyPoint;
    private Vector2 dir;
    private bool picked = false;
    private CoinScaler ects;
    void Start()
    {
        flyPoint = GameObject.Find("CoinDisappear").transform;
        ects = GameObject.Find("Coin").GetComponent<CoinScaler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (picked)
        {
            transform.Translate(dir * Time.deltaTime * 1.5f);
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * Controller.vel);
        }
        
        
        if(transform.position.x < Camera.main.transform.position.x - 15)
            Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            
            startFlying();
            //PICKUP SOUND but must be on player since the object is getting destroyed
//            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("CoinPicker"))
        {
            Controller.AddPoint();
            Destroy(gameObject);
            ects.Rescale();
        }
    }

    private void startFlying()
    {
        dir = new Vector2(flyPoint.transform.position.x - transform.position.x, flyPoint.transform.position.y - transform.position.y);
        picked = true;
    }
}
