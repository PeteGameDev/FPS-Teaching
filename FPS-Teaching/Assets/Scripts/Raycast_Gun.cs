using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Raycast_Gun : MonoBehaviour
{
    public float gunDamage, gunRange, fireRate, reloadTime;
    public int magSize, currentAmmo, reserveAmmo, impactForce;

    public GameObject impactEffect;
    public ParticleSystem muzzleFlash;
    
    public TMP_Text ammoText;

    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = magSize;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire && currentAmmo > 0){
            Shoot();
            currentAmmo--;
        }

        if(currentAmmo <= 0 && reserveAmmo > 0){
            Reload();
        }

        if(Input.GetKeyDown(KeyCode.R)){
            reserveAmmo = reserveAmmo + currentAmmo;
            currentAmmo = 0;
        }
        ammoText.SetText(currentAmmo.ToString() + " / " + reserveAmmo.ToString());
    }


    void Shoot(){
        muzzleFlash.Play();

        RaycastHit hit;
        nextFire = Time.time + fireRate;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, gunRange)){
            Debug.Log(hit.transform.name);
            Enemy_Target target = hit.transform.GetComponent<Enemy_Target>();
            if(target != null){
                target.TakeDamage(gunDamage);
            }
            if(hit.rigidbody != null){
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }

    }

    void Reload(){
        nextFire = Time.time + reloadTime;
        if(reserveAmmo > magSize){
            reserveAmmo = reserveAmmo - magSize;
            currentAmmo = magSize;
        }
        else{
            currentAmmo = reserveAmmo;
            reserveAmmo = 0;
        }
    }
}
