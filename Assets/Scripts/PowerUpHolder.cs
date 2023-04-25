using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHolder : MonoBehaviour
{
    //private GameObject prefab;
    public GameObject yerb;


    public GameObject getPrefab(string type)
    {
        if (type == "Speed")
        {
            return yerb;
        }
        return yerb;
    }
}
