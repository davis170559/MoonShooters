using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    //Position of the walls
    private float spawnRangeX = 30.0f;
    private float lowerBound = -24.0f;
    private float topBound = 14.2f;
    //Variables used to spawn enemies
    private float startDelay = 1.5f;
    private float spawnInterval = 1.0f;
    public int enemyCount;
    public float timer;
    int enemiesToSpawn;
    int enemiesSpawned = 0;
    bool spawning = false; //Used as reference to know if the function is running
    private float waveNumber = 0;
    
    public GameObject bossPrefab;
    
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        waveNumber = 1;
        InvokeRepeating("SpawnEnemyWave", startDelay, spawnInterval);
        spawning = true; 
        timer = waveNumber * 5 + 14;
        enemiesToSpawn=5;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.UpdateWaveText(waveNumber);
    }
    
    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        timer -= Time.deltaTime;//Timer countdown. If it reaches zero, starts new wave
        if ((enemyCount == 0||timer<=0)&&!spawning) //If there is no enemies or the timer has finished and the function isn´t running
        {
            spawning = true;
            waveNumber++;
            gameManager.UpdateWaveText(waveNumber);
            if (waveNumber == 8) //Final Wave
            {
                SpawnBoss();
            }
            else
            {
                enemiesToSpawn += (int)(waveNumber*2);
                timer = waveNumber * 5f + 14f;
                InvokeRepeating("SpawnEnemyWave", startDelay, spawnInterval);

            }
            
        }
        if (enemiesSpawned >= enemiesToSpawn) //If all the enemies have been spawned, stops the function and restart values
        {
            CancelInvoke("SpawnEnemyWave");
            enemiesSpawned = 0;
            spawning = false;
        } 
    }
    public void SpawnBoss()
    {
        Instantiate(bossPrefab, bossPrefab.transform.position, bossPrefab.transform.rotation);
    }
    void SpawnEnemyWave()
    {
        int enemyIndex = Random.Range(0,enemyPrefab.Length); //It was suposed to be more :(
        int random = Random.Range(1,4); //To choose position
        Vector3 spawnPos = setPosition(random); //Gets the position where will spawn the enemy 
        Instantiate(enemyPrefab[enemyIndex], spawnPos, transform.rotation * Quaternion.Euler(0, (random-1)*90f, 0)); //The last thing is to correct the rotation of the object
        enemiesSpawned++;

    }
    Vector3 setPosition(int random)
    {
        switch (random)
        {
            case 1: //Spawns at bottom
                return new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1, lowerBound);
                //break;
            case 2: //Spawns at left
                return new Vector3(-spawnRangeX, 1, Random.Range(lowerBound, topBound));
            //break;
            case 3: //Spawns at top
                return new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1, topBound);
                //break;
            case 4: //Spawns at right
                return new Vector3(spawnRangeX, 1, Random.Range(lowerBound, topBound));
                //break;
            default: //Default spawns at right
                return new Vector3(spawnRangeX, 1, Random.Range(lowerBound, topBound));
                //break;
        }
        
    }
}
