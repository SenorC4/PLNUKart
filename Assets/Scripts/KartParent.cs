using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartParent : MonoBehaviour
{
    private float topSpeed;
    private float acceleration;
    private float handling;


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
    }

    public void setAcceleration(float acceleration)
    {
        this.acceleration = acceleration;
    }

    public void setHandling(float handling)
    {
        this.handling = handling;
    }

    
}
