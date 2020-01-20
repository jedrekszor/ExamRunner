using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn : MonoBehaviour
{
    public List<GameObject> blocks;
    public List<float> spawns;
    public Transform spawnPoint;
    public float minTime;
    public float maxTime;
    void Start()
    {
        StartCoroutine(Cooldown());
    }
    
    private IEnumerator Cooldown()
    {
//        Debug.Log("dupa");
        float sec = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(sec);
        spawnStuff();
    }

    private void spawnStuff()
    {
        int rand = Random.Range(0, blocks.Count);
        Instantiate(blocks[rand], spawnPoint.transform.position, Quaternion.identity);

        int randSpawn = Random.Range(0, spawns.Count);
        spawnPoint.transform.position = new Vector2(spawnPoint.position.x, spawns[randSpawn]); 
        StartCoroutine(Cooldown());
    }
}
