using System;
using System.Collections;
using UnityEngine;

public class EnemyController : Subject
{
	public PlayerController PlayerReference => playerReference;
	public ParticleSystem deathParticles;
	public GameObject RadicalizedEnemy;
	public int value;

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
			DestroyEnemy();
		}
	}

	private void DestroyEnemy()
	{
		if(RadicalizedEnemy == null) {
			//aici cand inamicul nu mai are radical si trebuie dat bonus la player
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
		yield return new WaitForSeconds(2);

		//TODO: add bonus to player
		enemySpawnerController.SpawnRadicalizedVersion(RadicalizedEnemy, transform.position);
		Destroy(gameObject);
	}
}
