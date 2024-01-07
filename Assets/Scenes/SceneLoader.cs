using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    private GameObject Loading;
    private GameObject Menu;

    void Start (){
        Loading = GameObject.Find("LOADING");
        Menu = GameObject.Find("Menu");
    }

    public void LoadScene(string sceneName) //Public procedure
    {
        SceneManager.LoadScene(sceneName); //Load Scene from sceneName string
    }

    public void ExitGame() 
    {
        Application.Quit(); //Quit game
        print("Exiting..."); //Debug log to check code works
    }

    public void NewGame(){
        Menu.SetActive(false);
        Loading.SetActive(true);
        LoadScene("Game");
    }
}
