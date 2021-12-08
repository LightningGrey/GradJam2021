using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public GameObject body;
    public Transform startPoint;
    public Transform endPoint;

    public float speed = 1;

    private int dir = -1;

    // Start is called before the first frame update
    void Start()
    {
        body.transform.position = startPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(body.transform.position.x < endPoint.transform.position.x)
        {
            dir *= -1;
            body.transform.position = endPoint.position;
        }
        else if(body.transform.position.x > startPoint.transform.position.x)
        {
            dir *= -1;
            body.transform.position = startPoint.position;
        }

        //Move enemy
        Vector2 my_normal = body.transform.position.normalized;
        body.transform.position += new Vector3(my_normal.x, 0f , 0f) * dir * speed * Time.deltaTime;
    }
}
