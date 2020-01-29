using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceIndicator : MonoBehaviour
{
    private GameObject session, player;
    private float dist;
    
    void Start()
    {
        session = GameObject.Find("Session");
        player = GameObject.Find("Player");
    }
    
    void Update()
    {
        dist = Mathf.Abs(session.transform.position.x - player.transform.position.x) - 2.8f;
        transform.localScale = new Vector3(dist/30, transform.localScale.y, transform.localScale.z);
    }
}
