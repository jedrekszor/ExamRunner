using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn : MonoBehaviour
{
    public List<GameObject> blocks;
    public List<GameObject> powerUps;
    public GameObject ects;
    public Transform spawnPoint;
    public float minTime;
    public float maxTime;
    public int powerUpRatio;
    public int ectsRatio;
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
        GameObject inst = Instantiate(blocks[rand], spawnPoint.transform.position, Quaternion.identity);
        int upOrDown = Random.Range(0, 2);
        int of = 0;
        if (upOrDown == 0)
            of = 2;
        else if (upOrDown == 1)
            of = -2;
        Vector3 pos = new Vector3(inst.transform.position.x, inst.transform.position.y + of, inst.transform.position.z);
        int powerUpChance = Random.Range(0, powerUpRatio);
        if (powerUpChance == 0)
        {
            int ectsChance = Random.Range(0, ectsRatio);
            if (ectsChance == 0)
            {
                Instantiate(ects, pos, Quaternion.identity);
            }
            else
            {
                int randPowerUp = Random.Range(0, powerUps.Count);
                Instantiate(powerUps[randPowerUp], pos, Quaternion.identity);
            }
        }

        int randSpawn = Random.Range(0, transform.childCount);
        spawnPoint.transform.position = transform.GetChild(randSpawn).transform.position; 
        StartCoroutine(Cooldown());
    }
}
