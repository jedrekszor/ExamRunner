using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitate : MonoBehaviour
{
    private int cnt = 0;
    private int yDir = 1;
    public float vel;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, yDir, 0) * Time.deltaTime * vel);
        if (cnt == 40)
        {
            cnt = 0;
            yDir *= -1;
        }

        cnt++;
    }
}
