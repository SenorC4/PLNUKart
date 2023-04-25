using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSpeedBoost : PowerUpParent
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        //prefab = GetComponent<GameObject>();
        typeOfPowerUp = "Speed";
        powerTimer = 5;
        charges = 1;
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
