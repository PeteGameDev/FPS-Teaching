using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Basic_Enemy : MonoBehaviour
{   
    public float damageAmount, attackDelay, attackRate, attackDistance;
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
    }

    void Attack(){
        //Melee Attack
        playerObject.GetComponent<Player_Health>().playerHealth -= damageAmount;
        attackDelay = Time.time + attackRate;
    }

    void Move(){
        navAgent.destination = playerObject.transform.position;
    }
}



