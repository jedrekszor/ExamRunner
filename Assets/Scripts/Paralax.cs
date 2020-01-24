using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    private GameObject bg;
    private GameObject layer1;
    private GameObject layer2;
    private GameObject layer3;

    private Renderer layer1Rend;
    private Renderer layer2Rend;
    private Renderer layer3Rend;

    public float scrollSpeed1;
    public float scrollSpeed2;
    public float scrollSpeed3;
    
    public static bool canParalax = true;
    // Start is called before the first frame update
    void Start()
    {
        bg = transform.GetChild(0).gameObject;
        layer1 = transform.GetChild(1).gameObject;
        layer2 = transform.GetChild(2).gameObject;
        layer3 = transform.GetChild(3).gameObject;

        layer1Rend = layer1.GetComponent<Renderer>();
        layer2Rend = layer2.GetComponent<Renderer>();
        layer3Rend = layer3.GetComponent<Renderer>();

      
    }
    
    void Update()
    {
//        scrollSpeed1 = 0;
//        scrollSpeed2 = 0;
//        
//        if (canParalax)
//        {
//            scrollSpeed1 = scrollSpeed1temp;
//            scrollSpeed2 = scrollSpeed2temp;
//        }

        Vector2 offset1 = new Vector2(Time.time * scrollSpeed1, 0);
        Vector2 offset2 = new Vector2(Time.time * scrollSpeed2, 0);
        Vector2 offset3 = new Vector2(Time.time * scrollSpeed3, 0);
    
        layer1Rend.material.mainTextureOffset = offset1;
        layer2Rend.material.mainTextureOffset = offset2;
        layer3Rend.material.mainTextureOffset = offset3;
        
        
    }
}
