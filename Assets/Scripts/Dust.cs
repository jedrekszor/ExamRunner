using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : MonoBehaviour
{
    public float time;
    void Start()
    {
        StartCoroutine(destroy());
    }

    private IEnumerator destroy()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
