using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PowerUp",
    menuName = "Scriptable Objects/PowerUps/Shield")]
public class ShieldPower : PowerUpData {
    public override void effect(GameObject balloon) {
        balloon.GetComponent<Health>().ActivateShield();
    }
}
