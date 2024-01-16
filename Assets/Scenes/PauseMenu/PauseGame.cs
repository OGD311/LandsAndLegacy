using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour{
    private bool isPaused = false;

    private GameObject Pause;
    private GameObject UI;
    private GameObject Loading;

    void Start(){
        Pause = GameObject.Find("PAUSED");
        UI = transform.Find("PlayerUI")?.gameObject;
        Loading = GameObject.Find("LOADING");
        Pause.SetActive(false);
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.P) && !Loading.activeInHierarchy){
            UI.SetActive(!UI.activeInHierarchy);
            Pause.SetActive(!Pause.activeInHierarchy);
            isPaused = !isPaused;
            print(isPaused);
            updatePause(isPaused);
        }
    }

    private void updatePause(bool isPaused){
        if (isPaused){
            Time.timeScale = 0;
        }
        else{
            Time.timeScale = 1;
        }
        
    }
}
