using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text inGameTimer;
    public TMP_Text place;

    private TMP_Text endTimer;
    private GameObject endScreen;

    private float timer;
    //private MainMenu menu;
    private string gameType;
    // Start is called before the first frame update
    void Start()
    {
        gameType = MainMenu.getGameType();
        endScreen = GameObject.FindGameObjectWithTag("EndScreen0");
        endTimer = GameObject.FindGameObjectWithTag("TimerText").GetComponent<TMP_Text>();
        
        
        if(gameType != "TimeTrial"){
            inGameTimer.gameObject.SetActive(false);
            place.gameObject.SetActive(true);
            
        }else{
            inGameTimer.gameObject.SetActive(true);
            place.gameObject.SetActive(false);
            endTimer.gameObject.SetActive(false);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Movement.getStarted()){
            
            timer += Time.deltaTime;
            if (gameType == "TimeTrial")
            {
                inGameTimer.text = timer.ToString("F2");
                endTimer.text = timer.ToString("F2");
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
