using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

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
    public Transform frontEnd;
    private GameObject prefab;
    private bool createdTopSpeed = false, createdAcceleration = false, createdHandling = false;
    private bool hasPowerUp = false, usingPowerUp = false;
    private bool isBoosting = false;
    private bool hitRamp = false;
    private bool isHit = false;
    private float hitTime = 0, tempHitTime = 0;
    private float rampTimer = 5;
    private float tempRampTimer = 0;

    private PlayerInput playerInput;


    // Start is called before the first frame update
    void Start()
    {
        //playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    public void Update(PlayerInput pi)
    {
        //playerInput = prefab.GetComponent<PlayerInput>();
        if (isHit == true)
        {
            tempHitTime += Time.deltaTime;
            movement.setStats(0, 0, 0, false);
        }

        if (tempHitTime > hitTime)
        {
            tempHitTime = 0;
            isHit = false;
            resetStats();
            movement.setStats(acceleration, topSpeed, handling, isBoosting);
        }


        kartPos = rb.transform.position;
        if (hasPowerUp == true || charges != 0)
        {
            kartPos.y -= 1.8f;
            prefab.transform.position = kartPos;
            prefab.transform.rotation = rb.transform.rotation;

        }

        //(Input.GetKey(KeyCode.E) || Gamepad.current.buttonWest.wasPressedThisFrame)
        //pi.actions["Use"].WasPressedThisFrame();
        if (pi.actions["Use"].WasPressedThisFrame() && powerUps.Count != 0 && usingPowerUp == false)
        {


            List<float> changedStats = powerUps[0].activate(acceleration, topSpeed);
            acceleration = changedStats[0];
            topSpeed = changedStats[1];
            charges = changedStats[2];

            if (type == "TripleSpeed" || type == "SingleSpeed")
            {
                resetStats();
                isBoosting = true; 
                movement.setStats(acceleration, topSpeed, handling, isBoosting);
            }

            else if (type == "TripleShell" || type == "SingleShell")
            {
                GameObject singlePrefab = GameObject.FindGameObjectWithTag("Holder").GetComponent<PowerUpHolder>().getPrefab("SingleShell");
                GameObject firingPrefab = Instantiate(singlePrefab, frontEnd.position, frontEnd.rotation);
                firingPrefab.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
            }

            powerUpTimer = powerUps[0].getTimer();
            powerUps[0].decreaseCharges();
            charges--;
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
                Destroy(prefab);
                prefab = GameObject.FindGameObjectWithTag("Holder").GetComponent<PowerUpHolder>().getPrefab("DoubleShell");
                prefab = Instantiate(prefab, kartPos, Quaternion.identity);
            }
            else if (charges == 1 && type == "TripleSpeed")
            {
                Destroy(prefab);
                prefab = GameObject.FindGameObjectWithTag("Holder").GetComponent<PowerUpHolder>().getPrefab("SingleSpeed");
                prefab = Instantiate(prefab, kartPos, Quaternion.identity);
            }
            else if (charges == 1 && type == "TripleShell")
            {
                Destroy(prefab);
                prefab = GameObject.FindGameObjectWithTag("Holder").GetComponent<PowerUpHolder>().getPrefab("SingleShell");
                prefab = Instantiate(prefab, kartPos, Quaternion.identity);
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
        if (other.gameObject.tag == "Shell")
        {
            other.gameObject.SetActive(false);
            hit();
        }
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
            int range = Random.Range(0, 4);
            //range = 3;
            switch (range)
            {
                case 0: 
                    powerUps.Add(gameObject.AddComponent(typeof(SingleSpeedBoost)) as SingleSpeedBoost);
                    //Debug.Log(powerUps[0].getTimer());
                    type = "SingleSpeed";
                    break;
                case 1: 
                    powerUps.Add(gameObject.AddComponent(typeof(TripleSpeedBoost)) as TripleSpeedBoost);
                    //Debug.Log(powerUps[0].getTimer());
                    type = "TripleSpeed";
                    break;
                case 2:
                    if (MainMenu.getGameType() != "TimeTrial")
                    {
                        powerUps.Add(gameObject.AddComponent(typeof(SingleShell)) as SingleShell);
                        type = "SingleShell";
                    }
                    else
                    {
                        powerUps.Add(gameObject.AddComponent(typeof(SingleSpeedBoost)) as SingleSpeedBoost);
                        type = "SingleSpeed";
                    }
                    break;
                case 3:
                    if (MainMenu.getGameType() != "TimeTrial")
                    {
                        powerUps.Add(gameObject.AddComponent(typeof(TripleShell)) as TripleShell);
                        type = "TripleShell";
                    }
                    else
                    {
                        powerUps.Add(gameObject.AddComponent(typeof(TripleSpeedBoost)) as TripleSpeedBoost);
                        type = "TripleSpeed";
                    }
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

    public void hit()
    {
        rb.AddForce(0, 500, 0);
        isHit = true;
        hitTime = 2;
    }

}
