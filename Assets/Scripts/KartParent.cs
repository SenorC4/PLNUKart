using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartParent : MonoBehaviour
{
    private float topSpeed;
    private float acceleration;
    private float handling;
    private float originalTopSpeed;
    private float originalAcceleration;
    private float OriginalHandling;
    private Timer time;
    bool createdTopSpeed = false, createdAcceleration = false, createdHandling = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {


    
    }

    public float getTopSpeed()
    {
        return topSpeed;
    }

    public float getAcceleration()
    {
        return acceleration;
    }

    public float getHandling()
    {
        return handling;
    }

    public void setTopSpeed(float topSpeed)
    {
        this.topSpeed = topSpeed;
        if (createdTopSpeed == false) 
        { 
            originalTopSpeed = topSpeed;
            createdTopSpeed = true;
        }
    }

    public void setAcceleration(float acceleration)
    {
        this.acceleration = acceleration;
        if (createdAcceleration == false)
        {
            originalAcceleration = acceleration;
            createdAcceleration = true;
        }
    }

    public void setHandling(float handling)
    {
        this.handling = handling;
        if (createdHandling == false) 
        {
            OriginalHandling = handling;
            createdHandling = true;
        }
    }

    public void resetStats()
    {
        handling = OriginalHandling;
        acceleration = originalAcceleration;
        topSpeed = originalTopSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "StopWatch") 
        {
            time = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
            time.decreaseTime();
            other.gameObject.SetActive(false);
        }
    }

}
