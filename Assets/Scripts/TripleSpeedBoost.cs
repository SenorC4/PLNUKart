using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class TripleSpeedBoost : PowerUpParent
{
    // Start is called before the first frame update
    void Start()
    {
        //prefab = GetComponent<GameObject>();
        typeOfPowerUp = "TripleSpeed";
        powerTimer = 5;
        charges = 3;
    }

    public override List<float> activate(float acceleration, float topSpeed)
    {
        List<float> result = new List<float>();
        result.Add(acceleration * 3);
        result.Add(topSpeed * 1.25f);
        result.Add(charges);
        return result;
        //return acceleration * 100;
    }
}
