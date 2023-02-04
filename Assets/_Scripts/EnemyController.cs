using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	private PlayerController playerReference;
	public ParticleSystem deathParticles;
	private const float SPEED = 8;
	
	private void Start()
	{
		playerReference = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
	}

	public void Update()
	{
		transform.position = Vector2.MoveTowards(transform.position, playerReference.transform.position, SPEED * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			Instantiate(deathParticles, transform.position, Quaternion.identity);
			playerReference.Health--;	
			Destroy(gameObject);
		}
	}
}
