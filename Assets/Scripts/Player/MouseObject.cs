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
    private bool canBounce = true;


    void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }


    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.position.ReadValue().magnitude > 0.0f)
        {
            _mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            gameObject.transform.position = _mousePos;
        }
    }

    public void OnPosition(InputAction.CallbackContext ctx)
    {
        //_mousePos = Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>());
        //gameObject.transform.position = _mousePos;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Balloon" && canBounce)
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

    public IEnumerator SuspendBounce() {
        _collider.enabled = true;
        canBounce = false;
        yield return new WaitForSeconds(5f);
        canBounce = true;
    }
}
