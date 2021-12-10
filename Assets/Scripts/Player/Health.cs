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
    private bool shield = false;
    public float lives { get; private set; }

    private void Start()
    {
        //lives = startingLives;
    }

    public void OnDeath()
    {
        if (shield) {
            shield = false;
            Debug.Log("blocked");
        }
        else { 
            Debug.Log("die");
        }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ActivateShield() {
        shield = true;
    }
}
