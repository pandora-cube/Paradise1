using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject Monster;
    public float SpawnTime;

    public void StartSpawn()
    {
        StartCoroutine(MonsterSpawn());
    }

    public void StopSpawn()
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }
    IEnumerator MonsterSpawn()
    {
        Instantiate(Monster, transform);
        yield return new WaitForSeconds(SpawnTime);
        StartCoroutine("MonsterSpawn");
    }
}
