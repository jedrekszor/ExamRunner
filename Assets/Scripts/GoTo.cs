using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTo : MonoBehaviour
{
    public Transform goTo;
    
    void Update()
    {
        transform.position = new Vector3(goTo.position.x, transform.position.y, transform.position.z);
    }
}
