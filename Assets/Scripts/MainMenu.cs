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

    public void NextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void Split(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        gameType = "SplitScreen";
    }

    public void Lan(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        gameType = "Lan";
    }

    public void Quit(){
        Application.Quit();
    }

    public static string getGameType(){
        return gameType;
    }

}

