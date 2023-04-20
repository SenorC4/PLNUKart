using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class PowerUpParent : MonoBehaviour
{
    public string typeOfPowerUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public string getType()
    {
        return typeOfPowerUp;
    }
}
