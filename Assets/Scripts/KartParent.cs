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
    private float powerUpTimer;
    private float tempTimer;
    private Timer time;
    private List<PowerUpParent> powerUps;
    private Movement movement;
    bool createdTopSpeed = false, createdAcceleration = false, createdHandling = false;
    bool hasPowerUp = false, usingPowerUp = false;


    // Start is called before the first frame update
    void Start()
    {
        //powerUps = gameObject.AddComponent<List<PowerUpParent>>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.E) && powerUps.Count != 0)
        {
           acceleration = powerUps[0].activate(acceleration, topSpeed);
           movement.setStats(acceleration, topSpeed, handling);
           powerUpTimer = powerUps[0].getTimer();
           powerUps.Clear();
           hasPowerUp = false;
           usingPowerUp = true;
        }

        if (usingPowerUp == true)
        {
            tempTimer += Time.deltaTime;
        }

        if (tempTimer > powerUpTimer)
        {
            resetStats();
            movement.setStats(acceleration, topSpeed, handling);
            tempTimer = 0;
            usingPowerUp = false;
        }
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
        
        if (other.gameObject.tag == "Block" && hasPowerUp == false)
        {
            powerUps = new List<PowerUpParent>();
            powerUps.Add(gameObject.AddComponent(typeof(SingleSpeedBoost)) as SingleSpeedBoost);
            hasPowerUp = true;
            other.gameObject.SetActive(false);
        }
    }

    public void setMovement(Movement movement)
    {
        this.movement = movement;
    }

}
