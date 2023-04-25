using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHolder : MonoBehaviour
{
    //private GameObject prefab;
    public GameObject yerb;
    public GameObject doubleYerb;
    public GameObject tripleYerb;


    public GameObject getPrefab(string type)
    {
        if (type == "SingleSpeed")
        {
            return yerb;
        }
        else if (type == "DoubleSpeed")
        {
            return doubleYerb;
        }
        else if (type == "TripleSpeed")
        {
            return tripleYerb;
        }
        return yerb;
    }
}
