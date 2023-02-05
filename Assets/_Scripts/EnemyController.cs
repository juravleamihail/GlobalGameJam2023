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

	private BoxCollider2D boxCollider2D;
	private SpriteRenderer spriteRenderer;

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
		gameManager = FindObjectOfType<GameManager>();
		
		boxCollider2D  = GetComponent<BoxCollider2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
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
		Destroy(boxCollider2D);
		Destroy(spriteRenderer);
		yield return new WaitForSeconds(0.5f);

		enemySpawnerController.SpawnRadicalizedVersion(RadicalizedEnemy, transform.position);
		Destroy(gameObject);
	}
}
