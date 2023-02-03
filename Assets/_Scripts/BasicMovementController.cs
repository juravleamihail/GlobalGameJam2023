using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovementController : MonoBehaviour
{
    private const float SPEED = 10;
    [SerializeField] private Rigidbody2D rb2d;
 
    void Update()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
 
        rb2d.velocity = new Vector2 (moveHorizontal*SPEED, moveVertical*SPEED);
 
        // Try out this delta time method??
        //rb2d.transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
    }
 
    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
    }
}
