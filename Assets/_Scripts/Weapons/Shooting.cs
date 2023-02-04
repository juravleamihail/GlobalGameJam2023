using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
	//weapons
	public GameObject plusWeapon;
	public GameObject minusWeapon;
	public GameObject xWeapon;
	//swing dat weapon
	private float cooldown = 0.4f;
	private float lastSwing;

	SpriteRenderer spriteRend;

	void Update()
    {
		if (Input.GetKeyDown(KeyCode.Z))
		{
			if (Time.time - lastSwing > cooldown)
			{
				lastSwing = Time.time;
				PlusAtack();
			}
		}
		
		if (Input.GetKeyDown(KeyCode.X))
		{
			if (Time.time - lastSwing > cooldown)
			{
				lastSwing = Time.time;
				MinusAtack();
			}
		}
		if (Input.GetKeyDown(KeyCode.C))
		{
			if (Time.time - lastSwing > cooldown)
			{
				lastSwing = Time.time;
				XAtack();
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Destroy(collision.gameObject);
	}

	private void PlusAtack()
	{
		if (plusWeapon!=null)
		{
			plusWeapon.gameObject.SetActive(true);
		}
		
	}
	private void MinusAtack()
	{
		if (minusWeapon!=null)
		{
			minusWeapon.gameObject.SetActive(true);
		}
		
	}
	private void XAtack()
	{
		if (xWeapon!=null)
		{
			xWeapon.gameObject.SetActive(true);
		}
		
	}
}
