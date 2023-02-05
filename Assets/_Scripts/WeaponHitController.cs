using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponHitController : MonoBehaviour
{
    [SerializeField] private DestroyWeapon destroyWeapon;

    private void OnTriggerEnter2D(Collider2D col)
    {
        destroyWeapon.AudioSource.PlayOneShot(destroyWeapon.SoundManager.hitSounds[Random.Range(0, destroyWeapon.SoundManager.hitSounds.Count)]);
    }
}
