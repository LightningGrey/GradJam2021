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
    public float lives { get; private set; }

    private void Start()
    {
        //lives = startingLives;
    }

    public void OnDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
