using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingLives;
    public float lives { get; private set; }

    private void Start()
    {
        lives = startingLives;
    }

    public void OnDeath()
    {
        lives -= 1;
        Debug.Log(lives);
        if (lives <= 0)
        {
            // dead
            return;
        }
    }
}
