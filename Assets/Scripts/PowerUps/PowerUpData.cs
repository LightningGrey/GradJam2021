using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PowerUp",
    menuName = "Scriptable Objects/PowerUps/Default")]
public class PowerUpData : ScriptableObject
{
    public Sprite sprite;
    public string powerName;

    public virtual void effect(GameObject balloon) {

    }
}
