using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject enemyBerserker;
    public GameObject enemyArcher;
    public GameObject enemyBrute;
    public GameObject enemyBoss;

    public Vector3 spawnValues;
    public int enemyCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int enemiesAlive;

    public int waveNumber = 1;

    bool gameStart = true;
    bool nextLevel = false;

    void Start()
    {
        spawnValues = new Vector3(19.0f, -3.2f, 0f);
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if(enemiesAlive == 0)
        {
            enemyCount = (int)((waveNumber + 2));
            StartCoroutine(SpawnWaves());
        }
        if (!gameStart && nextLevel)
        {
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator SpawnWaves()
    {
        if (gameStart)
        {
            yield return new WaitForSeconds(startWait);
            while (enemiesAlive == 0)
            {
                waveNumber++;
                for (int i = 0; i < enemyCount; i++)
                {
                    Vector3 spawnPosition = new Vector3(Random.Range(spawnValues.x - 4.0f, spawnValues.x + 4.0f), spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    GameObject[] spawnedEnemy = new GameObject[] { enemyBerserker, enemyArcher, enemyBrute };
                    Instantiate(spawnedEnemy[Random.Range(0, spawnedEnemy.Length)], spawnPosition, spawnRotation);
                    enemiesAlive++;
                    gameStart = false;
                    nextLevel = true;
                    yield return new WaitForSeconds(spawnWait);
                }
            }
        }
        else
        {
            yield return new WaitForSeconds(waveWait);
            if ((waveNumber + 1) % 10 == 0)
            {

                while (enemiesAlive == 0)
                {
                    waveNumber++;
                    float minionCount = waveNumber * 1.5f;
                    Vector3 spawnPosition = new Vector3(Random.Range(spawnValues.x - 4.0f, spawnValues.x + 4.0f), spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(enemyBoss, spawnPosition, spawnRotation);
                    enemiesAlive++;

                    for (int i = 0; i < minionCount; i++)
                    {
                        GameObject[] spawnedEnemy = new GameObject[] { enemyBerserker, enemyArcher, enemyBrute };
                        Instantiate(spawnedEnemy[Random.Range(0, spawnedEnemy.Length)], spawnPosition, spawnRotation);
                        enemiesAlive++;
                        nextLevel = true;
                        yield return new WaitForSeconds(spawnWait);
                    }
                }
            }
            else
            {
                while (enemiesAlive == 0)
                {
                    waveNumber++;
                    for (int i = 0; i < enemyCount; i++)
                    {
                        Vector3 spawnPosition = new Vector3(Random.Range(spawnValues.x - 4.0f, spawnValues.x + 4.0f), spawnValues.y, spawnValues.z);
                        Quaternion spawnRotation = Quaternion.identity;
                        GameObject[] spawnedEnemy = new GameObject[] { enemyBerserker, enemyArcher, enemyBrute };
                        Instantiate(spawnedEnemy[Random.Range(0, spawnedEnemy.Length)], spawnPosition, spawnRotation);
                        enemiesAlive++;
                        nextLevel = true;
                        yield return new WaitForSeconds(spawnWait);
                    }
                }
            }
        }
    }


    IEnumerator NextLevel()
    {
        if(enemiesAlive == 0)
        {
            Debug.Log("Wave " + waveNumber + " Complete");
            nextLevel = false;
            StartCoroutine(SpawnWaves());
            yield return new WaitForSeconds(spawnWait);
        }
    }
}