using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnerController : MonoBehaviour, IObservable
{
    [SerializeField] private List<EnemyController> enemies;

    private float time;
    private int enemyCounter;
    private PlayerController playerReference;

    private void Awake()
    {
        playerReference = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    private void Start()
    {
        playerReference.Subscribe(this);
    }

    public void Update()
    {
        time += Time.deltaTime;
        if (time % 60 >= 0.5f)
        {
            if (enemyCounter < 5)
            {
                Instantiate(enemies[Random.Range(0, enemies.Count)], transform.position, quaternion.identity);
                enemyCounter++;
            }
            time = 0f;
        }
    }

    public void OnNotify()
    {
        enemyCounter--;
    }
}
