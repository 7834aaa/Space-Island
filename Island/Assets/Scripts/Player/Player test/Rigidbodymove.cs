using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rigidbodymove : CharacterMovement
{

    private new Rigidbody rigidbody;

    private void Start() => rigidbody = GetComponent<Rigidbody>();

    private void FixedUpdate() => rigidbody.MovePosition(transform.position + movementVector * movementSpeed * Time.fixedDeltaTime);
    




}
