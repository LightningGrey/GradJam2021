using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] private float fanSpeed;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Balloon")
        {
            //collision.gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(0, fanSpeed);

            Vector2 impulse = ((gameObject.transform.position - collision.gameObject.transform.position).normalized * fanSpeed) * -1;
            collision.gameObject.GetComponent<Balloon>().Impulse = impulse;
        }
    }
}
