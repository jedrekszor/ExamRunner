using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn : MonoBehaviour
{
    public List<GameObject> blocks;
    public List<GameObject> buffs;
    public List<GameObject> debuffs;
    public GameObject ects;
    public Transform spawnPoint;
    public float minTime;
    public float maxTime;
    public int powerUpRatio;
    public int ectsRatio;
    private int children;
    void Start()
    {
        children = transform.childCount;
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
        int randSpawn = Random.Range(0, children);
//        Debug.Log(children + " " + randSpawn);
        spawnPoint = transform.GetChild(randSpawn); 
        int rand = Random.Range(0, blocks.Count);
        GameObject inst = Instantiate(blocks[rand], spawnPoint.transform.position, Quaternion.identity);

        Vector3 pos = new Vector3(inst.transform.position.x, inst.transform.position.y + 1.5f, inst.transform.position.z);
        int powerUpChance = Random.Range(0, powerUpRatio);
        if (powerUpChance == 0)
        {
            int ectsChance = Random.Range(0, ectsRatio);
            if (ectsChance == 0)
            {
                Instantiate(ects, pos, Quaternion.identity);
            }
            else if (ectsChance >= 1 && ectsChance <= 3)
            {
                int randPowerUp = Random.Range(0, debuffs.Count);
                Instantiate(debuffs[randPowerUp], pos, Quaternion.identity);
            }
            else
            {
                int randPowerUp = Random.Range(0, buffs.Count);
                Instantiate(buffs[randPowerUp], pos, Quaternion.identity);
            }
        }
        
        StartCoroutine(Cooldown());
    }
}
