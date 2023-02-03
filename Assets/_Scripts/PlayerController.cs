using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Subject
{
    public int Health
    {
        get => health;
        set
        {
            NotifyObservers();
            health = value;
        }
    }

    private int health;
}
