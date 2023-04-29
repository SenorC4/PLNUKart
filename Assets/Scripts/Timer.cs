using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMPro.TMP_Text inGameTimer;
    private float timer;
    //private MainMenu menu;
    private string gameType;
    // Start is called before the first frame update
    void Start()
    {
        //menu = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainMenu>().getGameType();
        //gameType = menu.getGameType();
        gameType = MainMenu.getGameType();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameType);
        timer += Time.deltaTime;
        if (gameType == "TimeTrial")
        {
            inGameTimer.text = timer.ToString("F2");
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
