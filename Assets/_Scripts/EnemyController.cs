using System;
using System.Collections;
using UnityEngine;

public class EnemyController : Subject
{
	public PlayerController PlayerReference => playerReference;
	public ParticleSystem deathParticles;
	public GameObject RadicalizedEnemy;
	public int value;
	private GameManager gameManager;

	public EnemySpawnerController EnemySpawnerController
	{
		get => enemySpawnerController;
		set => enemySpawnerController = value;
	}
	
	private PlayerController playerReference;
	private EnemySpawnerController enemySpawnerController;

	private void Awake()
	{
		playerReference = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
		gameManager = GameObject.FindObjectOfType<GameManager>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Weapon"))
		{
			Instantiate(deathParticles, transform.position, Quaternion.identity);
			DestroyEnemy();
		}
		else if (other.gameObject.CompareTag("Player"))
		{
			playerReference.Health--;
			NotifyObservers();
			gameManager.life -= value;
			Destroy(gameObject);
		}
    }

	private void DestroyEnemy()
	{
        gameManager.AddHighscore(value);

        if (RadicalizedEnemy == null) {
			NotifyObservers();
			Destroy(gameObject);
		}
		else
		{
			StartCoroutine(WaitToSpawnNextEnemy());
		}
	}

	IEnumerator WaitToSpawnNextEnemy() 
	{
		Destroy(GetComponent<BoxCollider2D>());
		Destroy(GetComponent<SpriteRenderer>());
		yield return new WaitForSeconds(0.5f);

		enemySpawnerController.SpawnRadicalizedVersion(RadicalizedEnemy, transform.position);
		Destroy(gameObject);
	}
}
