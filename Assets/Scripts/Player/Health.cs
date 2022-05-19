using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingLives;
    [SerializeField] private float shakeLength;
    [SerializeField] private float shakePower;
    [SerializeField] private Animator _animator;
    private bool shield = false;
    private float deathTimer = 0.0f;
    public bool dead = false;
    public float lives { get; private set; }

    private void Start()
    {
        //lives = startingLives;
    }

    public void Update()
    {
        if (dead)
        {
            if (deathTimer <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                deathTimer -= Time.deltaTime;
            }
        }
    }

    public void OnDeath()
    {
        ScreenShakeController.Instance.StartShake(shakeLength, shakePower);

        if (shield) {
            shield = false;
            Debug.Log("blocked");
        }
        else { 
            Debug.Log("die");
            dead = true;
            //Start death timer
            deathTimer = shakeLength + 0.2f;
            //Freeze balloon rigidbody
            this.gameObject.transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            _animator.SetTrigger("Dead");
        }
    }
    public void ActivateShield() {
        shield = true;
    }
}
