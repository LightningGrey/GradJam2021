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

    //private Vector2 _distVector;
    private Vector2 _impulse = Vector2.zero;
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



}
