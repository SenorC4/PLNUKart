using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class TripleSpeedBoost : PowerUpParent
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        typeOfPowerUp = "Speed";
        powerTimer = 5;
        charges = 3;
    }

    public override List<float> activate(float acceleration, float topSpeed)
    {
        List<float> result = new List<float>();
        result.Add(acceleration * 50);
        result.Add(topSpeed * 2);
        result.Add(charges);
        return result;
        //return acceleration * 100;
    }
    public override GameObject getPrefab()
    {
        return prefab;
    }
}
