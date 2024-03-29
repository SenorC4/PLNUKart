using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckParent : MonoBehaviour
{
    private int p1currentCheck = 0;
    private int p2currentCheck = 0;

    private int maxChecks = 0;

    private int p1Laps = 0;
    private int p2Laps = 0;


    private static int first = 0;

    private void Start()
    {
        maxChecks = GameObject.FindGameObjectsWithTag("checkpoint").Length;

    }

    public int getCurrentCheck(int p)
    {
        switch(p)
        {
            case 1: return p1currentCheck;
            case 2: return p2currentCheck;
        }
        return p1currentCheck;
    }

    public int getMax()
    {
        return maxChecks;
    }

    public void setCurrentCheck(int c, int p)
    {
        switch(p)
        {
            case 1: p1currentCheck = c; GameObject.FindGameObjectWithTag("player1").GetComponent<Movement>().setCurrentCheck(p1currentCheck); break;
            case 2: p2currentCheck = c; GameObject.FindGameObjectWithTag("player2").GetComponent<Movement>().setCurrentCheck(p2currentCheck); break;
        }

        if(p1currentCheck > p2currentCheck && p1Laps >= p2Laps){
            first = 1;
        }else{
            first = 2;
        }
        
    }

    public static int getFirst(){
        return first;
    }

    public int getLaps(int p)
    {
        switch(p)
        {
            case 1: return p1Laps;
            case 2: return p2Laps;
        }
        return p1Laps;
    }

    public void setLaps(int p)
    {
        switch(p)
        {
            case 1: p1Laps++; GameObject.FindGameObjectWithTag("player1").GetComponent<Movement>().setLaps(p1Laps); break;
            case 2: p2Laps++; GameObject.FindGameObjectWithTag("player2").GetComponent<Movement>().setLaps(p2Laps); break;
        }
    }
}
