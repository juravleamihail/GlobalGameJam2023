using System;
using System.Collections;
using UnityEngine;

public class EnemyController : Subject
{
	public PlayerController PlayerReference => playerReference;
	public ParticleSystem deathParticles;
	public GameObject RadicalizedEnemy;
	public int points;
	public int damage;
	private GameManager gameManager;

	private BoxCollider2D boxCollider2D;
	private SpriteRenderer spriteRenderer;
	private bool isInvulnerable = true;

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

		isInvulnerable = true;
		StartCoroutine(WaitToChangeInvulnerabilityForEnemy());
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(isInvulnerable) {
			return;
        }

		if (other.gameObject.CompareTag("Weapon"))
		{
			Instantiate(deathParticles, transform.position, Quaternion.identity);
			DestroyEnemy();
		}
		else if (other.gameObject.CompareTag("Player"))
		{
			playerReference.Health--;
			NotifyObservers();
			gameManager.life -= damage;
			Destroy(gameObject);
		}
    }

	private void DestroyEnemy()
	{
        gameManager.AddHighscore(points);

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
		boxCollider2D.enabled = false;
		spriteRenderer.enabled = false;
		yield return new WaitForSeconds(0.3f);

		enemySpawnerController.SpawnRadicalizedVersion(RadicalizedEnemy, transform.position);
		NotifyObservers();
		Destroy(gameObject);
	}

    IEnumerator WaitToChangeInvulnerabilityForEnemy() {
        yield return new WaitForSeconds(0.3f);

		isInvulnerable = false;
    }
}
