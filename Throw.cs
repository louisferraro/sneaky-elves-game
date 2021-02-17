using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Direction launchDirection = PlayerMovement.currentDirection;

        if (launchDirection == Direction.Up)
            rb.velocity = transform.TransformDirection(Vector2.up * speed);
        if (launchDirection == Direction.Left)
            rb.velocity = transform.TransformDirection(Vector2.left * speed);
        if (launchDirection == Direction.Down)
            rb.velocity = transform.TransformDirection(Vector2.down * speed);
        if (launchDirection == Direction.Right)
            rb.velocity = transform.TransformDirection(Vector2.right * speed);
    }
}
