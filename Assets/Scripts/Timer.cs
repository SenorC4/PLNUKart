using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMPro.TMP_Text inGameTimer;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        inGameTimer.text = timer.ToString("F2"); 
    }

    public void decreaseTime()
    {
        timer -= 10;
        if (timer < 0)
        {
            timer = 0;
        }
    }

}
