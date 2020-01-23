using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECTS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * Controller.vel);
        
        if(transform.position.x < Camera.main.transform.position.x - 15)
            Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            Controller.AddPoint();
            //PICKUP SOUND but must be on player since the object is getting destroyed
            Destroy(gameObject);
        }
    }
}
