using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseObject : MonoBehaviour
{
    [Header("References")] [SerializeField]
    private Collider2D _collider;

    private Vector2 _mousePos;
    private Vector2 distVector;



    // Update is called once per frame
    void Update()
    {
    }

    public void OnPosition(InputAction.CallbackContext ctx)
    {
        _mousePos = ctx.ReadValue<Vector2>();
        _mousePos = Camera.main.ScreenToWorldPoint(_mousePos);
        gameObject.transform.position = _mousePos;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Balloon")
        {
            Vector2 impulse = (gameObject.transform.position - collision.gameObject.transform.position).normalized * -1;
            collision.gameObject.GetComponent<Balloon>().Impulse = impulse;

            StartCoroutine("Cooldown");
        }
    }

    IEnumerator Cooldown()
    {
        _collider.enabled = false;
        yield return new WaitForSeconds(1.5f);
        _collider.enabled = true;
    }

}
