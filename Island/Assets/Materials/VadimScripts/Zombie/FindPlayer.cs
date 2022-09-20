using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour
{
    public Transform Player;

    private void Update() {
        transform.LookAt(Player);
    }
}
