using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerController playerReference;
    private void Update()
    {
	    var playerPosition = playerReference.transform.position;
        transform.position = new Vector3(playerPosition.x, playerPosition.y, -1);
    }
}
