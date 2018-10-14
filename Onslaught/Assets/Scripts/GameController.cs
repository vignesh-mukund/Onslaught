using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject enemyBerserker;
    public GameObject enemyArcher;
    public GameObject enemyBrute;
    public Vector3 spawnValues;
    public int enemyCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int enemiesAlive;

    void Start()
    {
        spawnValues = new Vector3(19.0f, -3.2f, 0f);        
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(spawnValues.x - 4.0f, spawnValues.x + 4.0f), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                GameObject[] spawnedEnemy = new GameObject[] { enemyBerserker, enemyArcher, enemyBrute };
                Instantiate(spawnedEnemy[Random.Range(0, spawnedEnemy.Length)], spawnPosition, spawnRotation);
                enemiesAlive++;
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}