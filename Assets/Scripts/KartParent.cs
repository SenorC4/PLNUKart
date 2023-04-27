using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KartParent : MonoBehaviour
{
    private string type;
    private float charges;
    private float topSpeed;
    private float acceleration;
    private float handling;
    private float originalTopSpeed;
    private float originalAcceleration;
    private float OriginalHandling;
    private float powerUpTimer = 0;
    private float tempTimer = 0;
    private Vector3 kartPos;
    private Vector3 prefabPos;
    private Timer time;
    private List<PowerUpParent> powerUps;
    private Movement movement;
    public Rigidbody rb;
    private GameObject prefab;
    bool createdTopSpeed = false, createdAcceleration = false, createdHandling = false;
    bool hasPowerUp = false, usingPowerUp = false;
    bool isBoosting = false;
    bool hitRamp = false;
    float rampTimer = 5;
    float tempRampTimer = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        kartPos = rb.transform.position;
        if (hasPowerUp == true || charges != 0)
        {
            kartPos.y -= 1.8f;
            prefab.transform.position = kartPos;
            prefab.transform.rotation = rb.transform.rotation;

        }


        if (Input.GetKey(KeyCode.E) && powerUps.Count != 0 && usingPowerUp == false)
        {
            
            resetStats();
            if (type == "TripleSpeed" || type == "SingleSpeed")
            {
                isBoosting = true;
            }
            List<float> changedStats = powerUps[0].activate(acceleration, topSpeed);
            acceleration = changedStats[0];

            topSpeed = changedStats[1];
            charges = changedStats[2];
            powerUps[0].decreaseCharges();
            charges--;
            movement.setStats(acceleration, topSpeed, handling, isBoosting);
            powerUpTimer = powerUps[0].getTimer();
            if (charges == 0)
            {
                powerUps.Clear();
                Destroy(prefab);
                hasPowerUp = false;
            } 
            else if(charges == 2 && type == "TripleSpeed")
            {
                Destroy(prefab);
                prefab = GameObject.FindGameObjectWithTag("Holder").GetComponent<PowerUpHolder>().getPrefab("DoubleSpeed");
                prefab = Instantiate(prefab, kartPos, Quaternion.identity);
            }
            else if (charges == 2 && type == "TripleShell")
            {

            }
            else if (charges == 1 && type == "TripleSpeed")
            {
                Destroy(prefab);
                prefab = GameObject.FindGameObjectWithTag("Holder").GetComponent<PowerUpHolder>().getPrefab("SingleSpeed");
                prefab = Instantiate(prefab, kartPos, Quaternion.identity);
            }
            else if (charges == 1 && type == "TripleShell")
            {

            }
            usingPowerUp = true;    
        }

        if (usingPowerUp == true)
        {
            tempTimer += Time.deltaTime;

        }

        if (tempTimer > powerUpTimer)
        {
            resetStats();
            movement.setStats(acceleration, topSpeed, handling, isBoosting);
            tempTimer = 0;
            usingPowerUp = false;
        }

        if (hitRamp == true)
        {
            tempRampTimer += Time.deltaTime;
            if (tempRampTimer > rampTimer) 
            {
                tempRampTimer = 0;
                resetStats();
                movement.setStats(acceleration, topSpeed, handling, isBoosting);
                hitRamp = false;
            }
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
        isBoosting = false;
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
        if (other.gameObject.tag == "SpeedRamp" && hitRamp == false)
        {
            resetStats();
            hitRamp = true;
            isBoosting = true;
            acceleration = acceleration * 5;
            topSpeed = topSpeed * 2.75f;
            movement.setStats(acceleration, topSpeed, handling, isBoosting);
        }

        if (other.gameObject.tag == "Block" && hasPowerUp == false)
        {
            powerUps = new List<PowerUpParent>();
            int range = Random.Range(0, 2);
            switch (range)
            {
                case 0: powerUps.Add(gameObject.AddComponent(typeof(SingleSpeedBoost)) as SingleSpeedBoost);
                    Debug.Log(powerUps[0].getTimer());
                    type = "SingleSpeed";
                    break;
                case 1: powerUps.Add(gameObject.AddComponent(typeof(TripleSpeedBoost)) as TripleSpeedBoost);
                    Debug.Log(powerUps[0].getTimer());
                    type = "TripleSpeed";
                    break;
                default:
                    break;
            }
            hasPowerUp = true;
            other.gameObject.SetActive(false);
            prefab = GameObject.FindGameObjectWithTag("Holder").GetComponent<PowerUpHolder>().getPrefab(type);
            kartPos = rb.transform.position;
            prefabPos = new Vector3(kartPos.x, kartPos.y - 2, kartPos.z);
            prefab = Instantiate(prefab, prefabPos, Quaternion.identity);
        }
    }

    public void setMovement(Movement movement)
    {
        this.movement = movement;
    }

}
