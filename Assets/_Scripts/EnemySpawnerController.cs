using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


[Serializable]
public struct EnemyWave
{
    [SerializeField] public List<EnemyController> enemies;
    [SerializeField] public int enemiesPerWave;
}

public class EnemySpawnerController : Subject, IObservable
{
    [SerializeField] private List<EnemyWave> enemyWaves;

    public bool Spawning;
    public int AliveEnemies => aliveEnemies;

    private float time;
    private int enemyCounter;
    private PlayerController playerReference;
    private int aliveEnemies;
    private bool inBounds;
    private int currentWave;

    private void Awake()
    {
        playerReference = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    private void Start()
    {
       // playerReference.Subscribe(this);
    }

    public void Update()
    {
        time += Time.deltaTime;
        CheckPosition();
        if (Spawning && inBounds)
        {
            aliveEnemies = enemyWaves[currentWave].enemiesPerWave;
            if (time % 60 >= 0.5f)
            {
                if (enemyCounter < enemyWaves[currentWave].enemiesPerWave)
                {
                    var enemy = Instantiate(enemyWaves[currentWave].enemies[Random.Range(0, enemyWaves[currentWave].enemies.Count)], transform.position, quaternion.identity);
                    var enemyController = enemy.GetComponent<EnemyController>();
                    enemyController.Subscribe(this);
                    enemyController.EnemySpawnerController = this;
                    
                    enemyCounter++;
                }
                else
                {
                    Spawning = false;
                    enemyCounter = 0;
                    currentWave++;
                }
                time = 0f;
            }
        }
    }

    public void SpawnRadicalizedVersion(GameObject radicalizedEnemy, Vector3 position)
    {
        Debug.Log("test");
        var enemy = Instantiate(radicalizedEnemy, position, quaternion.identity);
        enemy.GetComponent<EnemyController>().Subscribe(this);
        enemyCounter++;
    }

    private void CheckPosition()
    {
        var spawnerPosition = transform.position;
        if (spawnerPosition.y is > 107 or < -107)
        {
            inBounds = false;
        }
        else if(spawnerPosition.x is > 128 or < -128)
        {
            inBounds = false;
        }
        else
        {
            inBounds = true;
        }
    }

    public void OnNotify()
    {
        aliveEnemies--;
        if (aliveEnemies == 0)
        {
            NotifyObservers();
        }
    }
}
