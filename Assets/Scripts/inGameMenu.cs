using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class inGameMenu : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject endScreen;

    

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    

    // Update is called once per frame
    void Update()
    {
        if(playerInput.actions["OpenMenu"].WasPressedThisFrame() && !startMenu.activeSelf){
            startMenu.SetActive(true);
            Time.timeScale = 0;

        }else if(playerInput.actions["OpenMenu"].WasPressedThisFrame() && startMenu.activeSelf){
            startMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void resume(){
        startMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit(){
        Application.Quit();
    }

    public void quitToMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
