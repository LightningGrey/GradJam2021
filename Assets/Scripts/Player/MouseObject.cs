using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseObject : MonoBehaviour
{ 
    [Header("References")]

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
            Debug.Log("true");
            Vector2 impulse = (gameObject.transform.position - collision.gameObject.transform.position).normalized * -1;
            collision.gameObject.GetComponent<Balloon>().Impulse = impulse;
        }
    }

}
