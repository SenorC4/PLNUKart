using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSpeedBoost : PowerUpParent
{
    
    // Start is called before the first frame update
    void Start()
    {
        typeOfPowerUp = "SingleBoost";
        powerTimer = 15;
    }

    public override float activate(float acceleration, float topSpeed)
    {
        return acceleration * 100;
    }
}
