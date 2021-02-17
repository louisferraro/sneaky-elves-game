using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    public float speed; // TODO: data
    public float waitTime;
    public float startWaitTime;
    public Transform moveSpot;
    // boundaries for our enemy ai
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    // this is the elf. Use it to access his position
    public GameObject hero;
    public float viewDistance = 10f; // distance between enemy and hero to initiate chasing
    public Rigidbody2D rb;
    public Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // this is the elfs position
        // Debug.Log(hero.transform.position);

        // enemy will move to a random location in level
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);


        // vision cone ai
        if(Vector2.Distance(transform.position, hero.transform.position) < viewDistance)
        {
            // hero is inside enemy vision cone
            Vector2 direction = hero.transform.position - transform.position;
            //direction.Normalize();
            movement = direction;

            // vision cone ai
            if (Vector2.Distance(transform.position, hero.transform.position) < viewDistance)
            {
                // hero is inside enemy vision cone
                moveCharacter(movement);
            }
        }


        if(Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}
