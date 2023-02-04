using System;
using UnityEngine;

public class EnemyController : Subject
{
	private PlayerController playerReference;
	
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
			playerReference.Health--;
			NotifyObservers();
			Destroy(gameObject);
		}
	}
}
