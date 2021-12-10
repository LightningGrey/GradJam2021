using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEditor.SearchService.Scene;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingLives;
    [SerializeField] private float shakeLength;
    [SerializeField] private float shakePower;
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
            deathTimer = shakeLength;
            //Freeze balloon rigidbody
            this.gameObject.transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            //TODO: Prob start death animation (make shake length = death animation length)
        }
    }
    public void ActivateShield() {
        shield = true;
    }
}
