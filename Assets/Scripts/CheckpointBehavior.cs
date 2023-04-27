using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBehavior : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int checkNum;

    private CheckParent cp;
    private MeshRenderer mr;

    private void Start()
    {
        cp = gameObject.GetComponentInParent<CheckParent>();
        mr = gameObject.GetComponent<MeshRenderer>();
        //mr.forceRenderingOff = true;
    }

    public int getCheckNum()
    {
        return checkNum;
    }

    public void checkHit(int p)
    {
        if (cp.getCurrentCheck(p) == checkNum)
        {
            mr.enabled = false;
            cp.setCurrentCheck(checkNum + 1, p);
            if (cp.getCurrentCheck(p) >= cp.getMax())
            {
                cp.setCurrentCheck(0, p);
                cp.setLaps(p);
            }
            Debug.Log("Player" + p + ": Checkpoint " + cp.getCurrentCheck(p));
        }
    }
}