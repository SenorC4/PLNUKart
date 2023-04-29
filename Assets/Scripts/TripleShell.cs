using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class TripleShell : PowerUpParent
{
    void Start()
    {
        //prefab = GetComponent<GameObject>();
        charges = 3;
    }
    public override List<float> activate(float acceleration, float topSpeed)
    {
        List<float> result = new List<float>();
        result.Add(acceleration);
        result.Add(topSpeed);
        result.Add(charges);
        return result;
        //return acceleration * 100;
    }
}
