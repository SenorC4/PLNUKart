using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text inGameTimer;
    public TMP_Text place;

    public GameObject endTimer;
    public GameObject endScreen;

    private float timer;
    //private MainMenu menu;
    private string gameType;
    // Start is called before the first frame update
    void Start()
    {
        //menu = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainMenu>().getGameType();
        //gameType = menu.getGameType();
        gameType = MainMenu.getGameType();
        endScreen = GameObject.FindGameObjectWithTag("EndScreen0");
        endTimer = GameObject.FindGameObjectWithTag("EndTimer");

        if(gameType != "TimeTrial"){
            inGameTimer.gameObject.SetActive(false);
            place.gameObject.SetActive(true);
            endTimer.SetActive(false);
        }else{
            
            
            inGameTimer.gameObject.SetActive(true);
            place.gameObject.SetActive(false);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Movement.getStarted()){
            //Debug.Log(gameType);
            timer += Time.deltaTime;
            if (gameType == "TimeTrial")
            {
                inGameTimer.text = timer.ToString("F2");
                
                endTimer.GetComponent<TMP_Text>().text = timer.ToString("F2");
            }
        }
    }

    public void decreaseTime()
    {
        timer -= 3;
        if (timer < 0)
        {
            timer = 0;
        }
    }

}
