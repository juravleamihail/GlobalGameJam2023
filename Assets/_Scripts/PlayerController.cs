using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Subject
{
    [SerializeField] private AudioSource audioSource;
    public int Health
    {
        get => health;
        set
        {
            NotifyObservers();
            audioSource.Play();
            health = value;
        }
    }

    private int health;
}
