using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Ammo Box")){
            gameObject.GetComponentInChildren<Raycast_Gun>().reserveAmmo += 10;
            Destroy(other.gameObject);
        }
        if(other.CompareTag("Health Item")){
            gameObject.GetComponent<Player_Health>().playerHealth += 10f;
            Destroy(other.gameObject);
        }
        

        //here you could add in triggers for doors etc
    }

    void OnTriggerStay(Collider other){
        /*
        if(other.CompareTag("Door") && Input.GetKeyDown(KeyCode.E)){
            Destroy(other.gameObject);
            //alternatively play animation etc
        }*/
        if(other.CompareTag("Spike Hazard")){
            gameObject.GetComponent<Player_Health>().playerHealth--;
        }
    }
}
