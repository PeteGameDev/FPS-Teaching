using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Basic_Enemy : MonoBehaviour
{   
    public float damageAmount, attackDelay, attackRate, attackDistance, health;
    public Animator anims;
    GameObject playerObject;
    NavMeshAgent navAgent;

    

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        navAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(Time.time > attackDelay){
            Move();
            if(Vector3.Distance(playerObject.transform.position, transform.position) <= attackDistance){
                Attack();
            }
        }
        else navAgent.destination = transform.position;
        if(health <= 0f){
            Die();
        }
    }

    void Attack(){
        //Melee Attack
        playerObject.GetComponent<Player_Health>().playerHealth -= damageAmount;
        attackDelay = Time.time + attackRate;
        anims.SetBool("isRunning", false);
        anims.SetBool("isAttacking", true);
        
    }

    void Move(){
        navAgent.destination = playerObject.transform.position;
        anims.SetBool("isRunning", true);
        anims.SetBool("isAttacking", false);
    }
    

    public void TakeDamage(float amount){
        health -= amount;
        
    }

    void Die(){
        anims.SetBool("isDead", true);
        navAgent.destination = transform.position;
        Destroy(gameObject, 5f);
    }
}



