using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image bar;
    public static bool PlayerDied = false;
    public static float Health;

    private void Awake() {
        Health = 100f;
    }

    private void Update() {
        bar.fillAmount = Health / 100f;

        if(Health <= 0.0f){
            PlayerDied = true;
        }

        if(PlayerDied == true){
            Health = 100;
            PlayerDied = false;
        }
    }
}
