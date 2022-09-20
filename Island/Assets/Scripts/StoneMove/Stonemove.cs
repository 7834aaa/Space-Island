using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stonemove : MonoBehaviour
{
    public GameObject  Stone;
    public float speed;
   

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            Transform Stoneball = Instantiate(Stone.transform, gameObject.transform.position,Quaternion.identity);
            Stoneball.GetComponent<Rigidbody>().AddForce(transform.forward*speed);



        }


    }
}
