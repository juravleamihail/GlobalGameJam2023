using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour, IObservable
{
    [SerializeField] private int numberOfWaves;
    [SerializeField] private List<EnemySpawnerController> enemySpawners;

    private void Start()
    {
        foreach (var enemySpawner in enemySpawners)
        {
            enemySpawner.Subscribe(this);
        }
        NextWave();
    }

    private void NextWave()
    {
        foreach (var enemySpawner in enemySpawners)
        {
            enemySpawner.Spawning = true;
            enemySpawner.AliveEnemies = 0;
        }
        numberOfWaves--;
    }
    
    public void OnNotify()
    {
        foreach (var enemySpawner in enemySpawners)
        {
            if (enemySpawner.AliveEnemies > 0)
            {
                return;
            }
        }
        if (numberOfWaves > 0)
        {
            NextWave();
            Debug.Log("Number of waves = " + numberOfWaves);
        }
    }
}
