using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class SceneLoader : MonoBehaviour
{
    void Start (){
        Loading = GameObject.Find("LOADING");
        Menu = GameObject.Find("Menu");
        worldNameInput = GameObject.Find("WorldNameInput").GetComponent<TMP_InputField>();
        playerSeedInput = GameObject.Find("SeedInput").GetComponent<TMP_InputField>();
        worldSizeSlider = GameObject.Find("WorldSizeInput").GetComponent<Slider>();
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

    // Make a new Game world
    private GameObject Loading;
    private GameObject Menu;
    private TMP_InputField worldNameInput;
    private TMP_InputField playerSeedInput;
    private Slider worldSizeSlider;
    

    public void NewGame(){
        Menu.SetActive(false);
        Loading.SetActive(true);
        PlayerPrefs.SetString("worldName", worldNameInput.text);
        PlayerPrefs.SetString("playerSeed", playerSeedInput.text);
        PlayerPrefs.SetInt("worldSize", (int)(worldSizeSlider.value));
        LoadScene("Game");
    }
}
