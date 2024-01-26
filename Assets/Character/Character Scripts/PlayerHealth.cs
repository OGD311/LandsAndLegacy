using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static float health = 100f;
    private GameObject HealthManager;
    private Image HeartIcon;
    
    void Start(){
        HealthManager = gameObject;
        HeartIcon = HealthManager.transform.GetChild(1).gameObject.GetComponent<Image>(); // Find the heart Icon we want to edit
        HeartIcon.fillAmount = (health / 100); // Initialise fill (if health taken from save file)
    }

    public void UpdateHealth(float amount){ // Update the health icon
        health = health + amount;
        print(amount);
        health = Mathf.Clamp(health,0,100); // Clamp health between 100 (Full health) and 0 (Dead)
        HeartIcon.fillAmount = (health / 100); // Image fill amount is between 1 and 0 
    }


    void FixedUpdate(){
        if (health <= 0){
            GameSaves.LoadFromSave(PlayerPrefs.GetString("worldName")); //Load the scene
        }
        UpdateHealth(0.01f);// If not dead, then heal a small amount of health
    }


}
