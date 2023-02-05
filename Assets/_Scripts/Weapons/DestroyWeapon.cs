using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class DestroyWeapon : MonoBehaviour
{
	public Animation anim;
	public SoundManager SoundManager => soundManager;	
	public AudioSource AudioSource => audioSource;

	[SerializeField] private AudioSource audioSource;
	private SoundManager soundManager;


	private void Start()
	{
		soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
	}

	private void OnEnable()
	{
		if (soundManager == null)
		{
			soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
		}
		if (anim!=null)
		{
			anim.Play();
		}
		
		audioSource.PlayOneShot(soundManager.swingSounds[Random.Range(0, soundManager.swingSounds.Count)]);
		
		StartCoroutine(SetObjectInactive(0.2f));
	}

	IEnumerator SetObjectInactive(float secs)
	{
		yield return new WaitForSeconds(secs);
		gameObject.SetActive(false);
	}
}
