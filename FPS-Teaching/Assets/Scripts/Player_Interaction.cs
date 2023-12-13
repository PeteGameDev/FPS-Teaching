using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    bool healthItemEquipped = false;
    bool fireOn = false;
    //public GameObject healthItemIcon;
    
    public ParticleSystem firePS;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && healthItemEquipped == true){
            UseHealthItem();
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Ammo Box")){
            gameObject.GetComponentInChildren<Raycast_Gun>().reserveAmmo += 10;
            Destroy(other.gameObject);
        }
        if(other.CompareTag("Health Item") && healthItemEquipped == false){
            healthItemEquipped = true;
            //healthItemIcon.SetActive(true);
            Destroy(other.gameObject);
        }
    }

    void OnTriggerStay(Collider other){
        
        if(other.CompareTag("Fire") && Input.GetKey(KeyCode.F) && fireOn != true){
            firePS.Play();
            fireOn = true;
        }

        if(other.CompareTag("Spike Hazard")){
            gameObject.GetComponent<Player_Health>().playerHealth--;
        }
    }

    void UseHealthItem(){
        gameObject.GetComponent<Player_Health>().playerHealth += 10f;
        healthItemEquipped = false;
        //healthItemIcon.SetActive(false);
    }
}
