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
            case 1: p1currentCheck = c; break;
            case 2: p2currentCheck = c; break;
        }
        
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
            case 1: p1Laps++; Debug.Log("Player 1 Laps: " + p1Laps); break;
            case 2: p2Laps++; Debug.Log("Player 2 Laps: " + p2Laps); break;
        }
    }
}
