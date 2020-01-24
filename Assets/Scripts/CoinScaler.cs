using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScaler : MonoBehaviour
{
    public float offset;
    public float time;
    private bool canScale = false;
    void Update()
    {
        if(canScale)
            transform.localScale = new Vector3(transform.localScale.x + offset, transform.localScale.y + offset, transform.localScale.z);
    }

    public void Rescale()
    {
        offset = Mathf.Abs(offset);
        canScale = true;

        StartCoroutine(reverse());
    }

    private IEnumerator reverse()
    {
        yield return new WaitForSeconds(time);
        offset *= -1;
        yield return new WaitForSeconds(time);
        canScale = false;
    }
}
