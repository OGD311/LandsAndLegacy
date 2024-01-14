using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    private GameObject HealthManager;
    private GameObject HeartIcon;
    
    void Start(){
        HealthManager = gameObject;
        HeartIcon = HealthManager.transform.GetChild(1).gameObject;
    }

    public void Damage(float Damage){ // Update the health icon
        print("Taking "+Damage+" Damage");
        health = health - Damage;
        health = Mathf.Clamp(health,0,100); // Clamp health between 100 (Full health) and 0 (Dead)
        HeartIcon.GetComponent<Image>().fillAmount = (health / 100); // Image fill amount is between 1 and 0 
    }

    void FixedUpdate(){
        if (health <= 0){
            Destroy(GameObject.Find("PlayerCharacter"));
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


}
