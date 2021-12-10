using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public float jumpHeight = 100;
    public float timeBetweenJumps = 3;
    public float offsetFirstJump = 0;
    private bool isJumping = false;
    private float timer = 0;

    // Update is called once per frame
    void Update()
    {
        if(offsetFirstJump != 0)
        {
            if(timer > offsetFirstJump)
            {
                offsetFirstJump = 0;
                timer = 0;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
        else
        {
            if (!isJumping && timer >= timeBetweenJumps)
            {
                Jump();
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }

    void Jump()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        rb.AddForce(Vector2.up * jumpHeight);
        isJumping = true;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isJumping = false;
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            timer = 0;
        }
    }
}
