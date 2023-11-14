using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    public float playerHealth;
    public Slider healthSlider;

    void Start(){
        healthSlider.maxValue = playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = playerHealth;
        if(playerHealth <= 0){
            GameOver();
        }
    }

    void GameOver(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
