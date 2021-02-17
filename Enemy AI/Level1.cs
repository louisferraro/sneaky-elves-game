using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public float speed = 5; // TODO: data
    // boundaries for our enemy ai
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    // this is the elf. Use it to access his position
    public GameObject hero;
    public float viewDistance = 1f; // distance between enemy and hero to initiate chasing
    public Vector2 movement;
    public Rigidbody2D rb;

    // Start is called befmore the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = hero.transform.position - transform.position;
        direction.Normalize();
        movement = direction;

        // vision cone ai
        if (Vector2.Distance(transform.position, hero.transform.position) < viewDistance)
        {
            // hero is inside enemy vision cone
            moveCharacter(movement);
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}
