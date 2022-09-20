using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneHit : MonoBehaviour
{
    public GameObject StoneBallHit;
  
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Terrain"){
            GameObject ball_hit = Instantiate(StoneBallHit, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
