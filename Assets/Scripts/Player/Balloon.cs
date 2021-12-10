using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Balloon : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private MouseObject _mo;
    [SerializeField] private float shakeLength;
    [SerializeField] private float shakePower;

    //private Vector2 _distVector;
    private Vector2 _impulse = Vector2.zero;
    private Vector2 storedVelocity = Vector2.zero;
    public Vector2 Impulse
    {
        get => _impulse;
        set => _impulse = value;
    }

[Header("Variables")]
    [SerializeField] private float _forceCoefficient = 100.0f;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_impulse != Vector2.zero)
        {
            _rb.AddForce(_impulse * _forceCoefficient);
            _impulse = Vector2.zero;
        }

        _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, 20.0f);
    }


    public IEnumerator FrozenPowerUp(float duration) {
        storedVelocity = GetComponent<Rigidbody2D>().velocity;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(duration);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<Rigidbody2D>().velocity = storedVelocity;
    }
    public IEnumerator MagnetPowerUp(float duration) {
        float timer = 0.0f;
        _mo.StartCoroutine(_mo.SuspendBounce(duration));
        while (timer <= duration) {
            if (Vector2.Distance(_mo.gameObject.transform.position, gameObject.transform.position) <= 5) {
                Debug.Log(Vector2.Distance(_mo.gameObject.transform.position, gameObject.transform.position));
                Vector2 impulse = (_mo.gameObject.transform.position - gameObject.transform.position).normalized;
                _rb.AddForce(impulse * 6f);
            }
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            ScreenShakeController.Instance.StartShake(shakeLength, shakePower);
        }
    }

}
