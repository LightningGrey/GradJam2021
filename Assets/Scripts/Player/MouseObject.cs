using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MouseObject : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private Collider2D _collider;
    [SerializeField] private float _cooldown = 1.0f;
    [SerializeField] private float shakeLength;
    [SerializeField] private float shakePower;

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

        if (Keyboard.current.escapeKey.IsPressed())
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void OnPosition(InputAction.CallbackContext ctx)
    {
        //_mousePos = Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>());
        //gameObject.transform.position = _mousePos;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Balloon" && canBounce && !collision.gameObject.transform.GetComponent<Health>().dead)
        {
            Vector2 impulse = (gameObject.transform.position - collision.gameObject.transform.position).normalized * -1;
            collision.gameObject.GetComponent<Balloon>().Impulse = impulse;
            ScreenShakeController.Instance.StartShake(shakeLength, shakePower);
            StartCoroutine("Cooldown");
        }
    }

    IEnumerator Cooldown()
    {
        _collider.enabled = false;
        yield return new WaitForSeconds(_cooldown);
        _collider.enabled = true;
    }

    public IEnumerator SuspendBounce() {
        _collider.enabled = true;
        canBounce = false;
        yield return new WaitForSeconds(5f);
        canBounce = true;
    }
}
