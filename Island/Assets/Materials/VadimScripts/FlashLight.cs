using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject Light1, Light2;
    public static bool PickedUp = false;
    private bool IsEnabled = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L) & PickedUp == true){
            IsEnabled = !IsEnabled;
            Light1.SetActive(IsEnabled);
            Light2.SetActive(IsEnabled);
        }
    }
}
