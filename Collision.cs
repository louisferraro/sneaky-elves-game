using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if we died
        Debug.Log("hit detected, game over :(");

        // TODO: Death animation goes here

        // disable elf from scene (we can still access its data if we need though)
        this.gameObject.SetActive(false);
    }
}
