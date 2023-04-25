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
    private float powerUpTimer;
    private float tempTimer;
    private Vector3 kartPos;
    private Vector3 prefabPos;
    private Timer time;
    private List<PowerUpParent> powerUps;
    private Movement movement;
    public Rigidbody rb;
    private GameObject prefab;
    bool createdTopSpeed = false, createdAcceleration = false, createdHandling = false;
    bool hasPowerUp = false, usingPowerUp = false;


    // Start is called before the first frame update
    void Start()
    {
        //powerUps = gameObject.AddComponent<List<PowerUpParent>>();
        //rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Update()
    {
        kartPos = rb.transform.position;
        if (hasPowerUp == true || charges != 0)
        {
            kartPos.y -= 2;
            prefab.transform.position = kartPos;
            prefab.transform.rotation = rb.transform.rotation;

        }


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
            Debug.Log(powerUpTimer);
            if (charges == 0)
            {
                powerUps.Clear();
                Destroy(prefab);
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
                    //Debug.Log("single");
                    type = "SingleSpeed";
                    break;
                case 1: powerUps.Add(gameObject.AddComponent(typeof(TripleSpeedBoost)) as TripleSpeedBoost);
                    type = "TripleSpeed";
                    break;
                default:
                    break;
            }
            hasPowerUp = true;
            other.gameObject.SetActive(false);

            //type = powerUps[0].WhatKind();
            //Debug.Log(powerUps[0].WhatKind());
            //if (type == "SingleBoost")
            //{

            //}



            prefab = GameObject.FindGameObjectWithTag("Holder").GetComponent<PowerUpHolder>().getPrefab(type);
            kartPos = rb.transform.position;
            prefabPos = new Vector3(kartPos.x, kartPos.y - 2, kartPos.z - 1);
            prefab = Instantiate(prefab, prefabPos, Quaternion.identity);
            //kartPos.x -= 2;
            //GameObject prefab = powerUps[0].getPrefab();

        }
    }

    public void setMovement(Movement movement)
    {
        this.movement = movement;
    }

}
