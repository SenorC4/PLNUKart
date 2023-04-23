using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public abstract class PowerUpParent : MonoBehaviour
{
    public string typeOfPowerUp;
    public float powerTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public string getType()
    {
        return typeOfPowerUp;
    }

    public float getTimer()
    {
        return powerTimer;
    }

    public abstract float activate(float acceleration, float topSpeed);
}
