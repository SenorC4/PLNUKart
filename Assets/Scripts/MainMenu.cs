using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private static string gameType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TimeTrial(){
        SceneManager.LoadScene("KartPicker");
        gameType = "TimeTrial";
    }

    public void Split(){
        SceneManager.LoadScene("PLNUSouth");
        gameType = "SplitScreen";
    }

    public void Lan(){
        SceneManager.LoadScene("KartPicker");
        gameType = "Lan";
    }

    public void LanMenu(){
        SceneManager.LoadScene("LanMenu");
    }

    public void map(){
        SceneManager.LoadScene("PLNUSouth");
    }

    public void play(){
        if(gameType == "TimeTrial"){
            SceneManager.LoadScene("PLNUSouth");
        }else if(gameType == "Lan"){
            SceneManager.LoadScene("LanMenu");
        }
    
    }
    public void controls(){
        SceneManager.LoadScene("Controls");
    }

    public void pick(){
        SceneManager.LoadScene("KartPicker");
    }

    public void splitPick(){
        SceneManager.LoadScene("SplitKartPicker");
    }


    public void backToMain(){
        SceneManager.LoadScene("MainMenu");
    }

    public void back(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void Quit(){
        Application.Quit();
    }

    public static string getGameType(){
        return gameType;
    }

}

