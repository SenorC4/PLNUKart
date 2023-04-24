using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartParent : MonoBehaviour
{
    private float charges;
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
    private Rigidbody rb;
    bool createdTopSpeed = false, createdAcceleration = false, createdHandling = false;
    bool hasPowerUp = false, usingPowerUp = false;


    // Start is called before the first frame update
    void Start()
    {
        //powerUps = gameObject.AddComponent<List<PowerUpParent>>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Update()
    {

        if (Input.GetKey(KeyCode.E) && powerUps.Count != 0 && usingPowerUp == false)
        {
            List<float> changedStats = powerUps[0].activate(acceleration, topSpeed);
            acceleration = changedStats[0];
            topSpeed = changedStats[1];
            charges = changedStats[2];
            powerUps[0].decreaseCharges();
            charges--;
            movement.setStats(acceleration, topSpeed, handling);
            powerUpTimer = powerUps[0].getTimer();
            if (charges == 0)
            {
                powerUps.Clear();
            } 
            hasPowerUp = false;
            usingPowerUp = true;
            Debug.Log("test");
        }
        //Debug.Log("test");

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
            int range = Random.Range(0, 2);
            switch (range)
            {
                case 0: powerUps.Add(gameObject.AddComponent(typeof(SingleSpeedBoost)) as SingleSpeedBoost);
                    Debug.Log("single");
                    break;
                case 1: powerUps.Add(gameObject.AddComponent(typeof(TripleSpeedBoost)) as TripleSpeedBoost);
                    Debug.Log("triple");
                    break;
                default:
                    break;
            }
            hasPowerUp = true;
            other.gameObject.SetActive(false);
            GameObject prefab = powerUps[0].getPrefab();
            Instantiate(prefab);
        }
    }

    public void setMovement(Movement movement)
    {
        this.movement = movement;
    }

}
