using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetherableObject : MonoBehaviour
{
    public bool tethered;
    public CharacterMovement player;
    public float weight;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.OnGround())
        {
            this.GetComponent<Rigidbody>().useGravity = true;
        }
        else
        {
            this.GetComponent<Rigidbody>().useGravity = false;
        }
    }
}
