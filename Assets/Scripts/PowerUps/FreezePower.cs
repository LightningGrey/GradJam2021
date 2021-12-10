using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PowerUp",
    menuName = "Scriptable Objects/PowerUps/Freeze")]
public class FreezePower : PowerUpData
{
    public override void effect(GameObject balloon) {
        balloon.GetComponent<Balloon>().StartCoroutine(balloon.GetComponent<Balloon>().FrozenPowerUp(duration));
    }
}
