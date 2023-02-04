using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnerController : Subject, IObservable
{
    [SerializeField] private List<EnemyController> enemies;
    [SerializeField] private int enemiesPerWave;

    public bool Spawning;
    public int AliveEnemies => aliveEnemies;

    private float time;
    private int enemyCounter;
    private PlayerController playerReference;
    private int aliveEnemies;

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
        if (Spawning)
        {
            aliveEnemies = enemiesPerWave;
            if (time % 60 >= 0.5f)
            {
                if (enemyCounter < enemiesPerWave)
                {
                    var enemy = Instantiate(enemies[Random.Range(0, enemies.Count)], transform.position, quaternion.identity);
                    enemy.GetComponent<EnemyController>().Subscribe(this);
                    enemyCounter++;
                }
                else
                {
                    Spawning = false;
                    enemyCounter = 0;
                }
                time = 0f;
            }
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
