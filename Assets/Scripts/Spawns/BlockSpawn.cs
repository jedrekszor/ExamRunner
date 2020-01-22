using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn : MonoBehaviour
{
    public List<GameObject> blocks;
    public Transform spawnPoint;
    public float minTime;
    public float maxTime;
    void Start()
    {
        StartCoroutine(Cooldown());
    }
    
    private IEnumerator Cooldown()
    {
        float sec = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(sec);
        spawnStuff();
    }

    private void spawnStuff()
    {
        int rand = Random.Range(0, blocks.Count);
        Instantiate(blocks[rand], spawnPoint.transform.position, Quaternion.identity);

        int randSpawn = Random.Range(0, transform.childCount);
        spawnPoint.transform.position = transform.GetChild(randSpawn).transform.position; 
        StartCoroutine(Cooldown());
    }
}
