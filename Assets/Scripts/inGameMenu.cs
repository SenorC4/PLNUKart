using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class inGameMenu : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] GameObject startMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInput.actions["OpenMenu"].WasPressedThisFrame() && !startMenu.activeSelf){
            startMenu.SetActive(true);
        }else if(playerInput.actions["OpenMenu"].WasPressedThisFrame() && startMenu.activeSelf){
            startMenu.SetActive(false);
        }
    }

    public void resume(){
        startMenu.SetActive(false);
    }

    public void Quit(){
        Application.Quit();
    }

    public void quitToMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
