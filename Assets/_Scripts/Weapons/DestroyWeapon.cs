using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWeapon : MonoBehaviour
{
	private void OnEnable()
	{
		StartCoroutine(SetObjectInactive(0.2f));
	}

	
 
	IEnumerator SetObjectInactive(float secs)
	{
		yield return new WaitForSeconds(secs);
		gameObject.SetActive(false);
	}
}
