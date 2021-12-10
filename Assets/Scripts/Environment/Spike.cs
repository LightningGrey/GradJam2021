using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Balloon")
        {
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
            collision.gameObject.GetComponent<Health>().OnDeath();
        }
    }
}
