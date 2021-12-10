using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _balloon;
    [SerializeField] private GameObject _scrollPoint;
    [SerializeField] private GameObject _mouse;

    [Header("Camera Scroll Values")]
    [SerializeField] private float _min = 0.0f;
    [SerializeField] private float _max = 50.0f;
    //positive keeps camera slightly behind, negative is slightly ahead
    [SerializeField] private float _offset = 0.5f; 


    private float _previousScroll;


    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //move scroll point
        _scrollPoint.transform.position = new Vector3(
            Mathf.Clamp(_balloon.transform.position.x + _offset, _min, _max), 0.0f, 0.0f);
    }
}
