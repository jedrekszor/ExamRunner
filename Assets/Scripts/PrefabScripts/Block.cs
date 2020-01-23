using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
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
}
