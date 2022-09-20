using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    public float Health;
    public static bool ZMBDied;
    public Camera MainCamera;

    private void Awake() {
        ZMBDied = false;
        Health = 100f;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Q) & ZMBDied == false){
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 5)){
                if(hit.collider.gameObject == this.gameObject){
                    Health -= Random.Range(15f, 35f);
                    if(Health <= 0){
                        ZMBDied = true;
                    }
                }
            }
        }
    }
}
