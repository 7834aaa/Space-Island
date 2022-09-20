using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFlashlight : MonoBehaviour
{
    public Camera MainCamera;
    public GameObject flashlight, LightInHand;

    private void Update() {
        if(Input.GetKey(KeyCode.E)){
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 5)){
                if(hit.collider.gameObject == flashlight){
                    FlashLight.PickedUp = true;
                    LightInHand.SetActive(true);
                    Destroy(flashlight);
                }
            }
        }
    }
}
