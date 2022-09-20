using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveCC : MonoBehaviour
{
    public float speedMove, jumpPower;
    private float speedMoveConst;
    private bool back = false;


    private float gravityForce;
    private Vector3 moveVector;
    private CharacterController ch_controller;
    private Animator ch_animator;


    private void Start() {
        ch_controller = GetComponent<CharacterController>();
        ch_animator = GetComponent<Animator>();
        speedMoveConst = speedMove;
    }

    private void Update() {
        CharacterMove();
        GamingGravity();
    }

    private void CharacterMove(){

        if(Input.GetKey(KeyCode.S)){
            back = true;
        }
        if(Input.GetKeyUp(KeyCode.S)){
            back = false;
        }
        if(Input.GetKey(KeyCode.LeftControl)){
            speedMove = speedMoveConst / 2;
        }
        if(Input.GetKeyUp(KeyCode.LeftControl)){
            speedMove = speedMoveConst;
        }



        if(ch_controller.isGrounded){
            ch_animator.ResetTrigger("Jump");
            ch_animator.SetBool("Falling", false);
            ch_animator.SetTrigger("Landed");
        }
        else{
            ch_animator.SetBool("Falling", true);
        }

        float x = Input.GetAxis("Horizontal") * speedMove;
        float z = Input.GetAxis("Vertical") * speedMove;

        if((x != 0) || (z != 0)){
            if(Input.GetKey(KeyCode.LeftShift)){
                speedMove = speedMoveConst * 2;
                if(back == false){
                    ch_animator.SetBool("Running", true);
                    ch_animator.SetBool("BackRunning", false);
                }
                if(back == true){
                    ch_animator.SetBool("BackRunning", true);
                    ch_animator.SetBool("Running", false);
                }
            }

            if(Input.GetKeyUp(KeyCode.LeftShift) ){
                speedMove = speedMoveConst;
                ch_animator.SetBool("Running", false);
                ch_animator.SetBool("BackRunning", false);
            }

            if(back == false){
                if(Input.GetKey(KeyCode.LeftShift)){
                    ch_animator.SetBool("Running", true);
                }
                ch_animator.SetBool("Move", true);
                ch_animator.SetBool("BackWalking", false);
            }
            if(back == true){
                if(Input.GetKey(KeyCode.LeftShift)){
                    ch_animator.SetBool("BackRunning", true);
                }
                ch_animator.SetBool("BackWalking", true);
                ch_animator.SetBool("Move", false);
            }
        }
        else{
            ch_animator.SetBool("Move", false);
            ch_animator.SetBool("BackWalking", false);
            ch_animator.SetBool("Running", false);
            ch_animator.SetBool("BackRunning", false);
        }
        
        Vector3 move = transform.right * x + transform.forward * z;
        move.y = gravityForce;
        ch_controller.Move(move * Time.deltaTime);
    }

    private void GamingGravity(){
        if(!ch_controller.isGrounded){
            gravityForce -= 20f * Time.deltaTime;
        }
        else{
            gravityForce = -1f;
        }
        
        if(Input.GetKeyDown(KeyCode.Space) && ch_controller.isGrounded ){
            gravityForce = jumpPower;
            ch_animator.SetTrigger("Jump");
        }
    }
}
