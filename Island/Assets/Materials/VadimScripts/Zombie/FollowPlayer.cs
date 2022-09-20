using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    private Animator zmb_animator;
    public GameObject Locator, Player;
    private bool attacked = false;
    private float timeAttack;
    RaycastHit hit;

    private void Start() {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        zmb_animator = GetComponent<Animator>();
        attacked = false;
    }

    void Update()
    {
        if(timeAttack > 1.5f){
            attacked = false;
            if(Physics.Raycast(Locator.transform.position, Locator.transform.forward, out hit, 1.5f)){
                HealthBar.Health -= Random.Range(10f, 25f);
                timeAttack = 0;
            }
        }

        if(Physics.Raycast(Locator.transform.position, Locator.transform.forward, out hit, 15) & attacked == false & ZombieDamage.ZMBDied == false){
            if(Physics.Raycast(Locator.transform.position, Locator.transform.forward, out hit, 7) & attacked == false){
                if(Physics.Raycast(Locator.transform.position, Locator.transform.forward, out hit, 2) & attacked == false){
                    timeAttack = 0;
                    agent.speed = 0;
                    zmb_animator.SetTrigger("Attack");
                    attacked = true;
                }
                else{
                    zmb_animator.ResetTrigger("Attack");
                    zmb_animator.SetBool("Run", true);
                    agent.speed = 5;
                    agent.destination = Player.transform.position;
                    zmb_animator.SetBool("Walk", false);
                    Debug.Log("PLAYER LOCATED 1");
                }
            }
            else{
                zmb_animator.ResetTrigger("Attack");
                zmb_animator.SetBool("Walk", true);
                agent.speed = 2;
                agent.destination = Player.transform.position;
                zmb_animator.SetBool("Run", false);
                Debug.Log("PLAYER LOCATED 2");
            }
        }
        else{
            zmb_animator.SetBool("Walk", false);
            zmb_animator.SetBool("Run", false);
        }

        if(attacked == true){
            timeAttack += Time.deltaTime;
        }

        if(ZombieDamage.ZMBDied == true){
            this.GetComponent<Collider>().enabled = false;
            zmb_animator.SetBool("Dead", true);
        }
    }
}
