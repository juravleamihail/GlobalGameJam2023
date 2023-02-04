using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyWeapon : MonoBehaviour
{
	public Animation anim;
	
	private void OnEnable()
	{
		if (anim!=null)
		{
			anim.Play();
		}
		
		StartCoroutine(SetObjectInactive(0.2f));
	}

	
 
	IEnumerator SetObjectInactive(float secs)
	{
		yield return new WaitForSeconds(secs);
		gameObject.SetActive(false);
	}
}
