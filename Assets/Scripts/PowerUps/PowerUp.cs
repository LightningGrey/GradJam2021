using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUp : MonoBehaviour
{

    private SpriteRenderer icon;
    public PowerUpData power;

    // Start is called before the first frame update
    void Start()
    {
        //icon = GetComponent<SpriteRenderer>();
        //icon.sprite = power.sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Balloon") {
            power.effect(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
