using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public abstract class PowerUpParent : MonoBehaviour
{
    public string typeOfPowerUp;
    public float powerTimer;
    public float charges;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public string WhatKind()
    {
        return typeOfPowerUp;
    }

    public float getTimer()
    {
        return powerTimer;
    }

    public void decreaseCharges()
    {
        charges--;
    }

    public abstract GameObject getPrefab();
    public abstract List<float> activate(float acceleration, float topSpeed);
}
