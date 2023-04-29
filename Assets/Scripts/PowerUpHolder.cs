using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHolder : MonoBehaviour
{
    //private GameObject prefab;
    public GameObject yerb;
    public GameObject doubleYerb;
    public GameObject tripleYerb;
    public GameObject SkateBoard;
    public GameObject DoubleSkateBoard;
    public GameObject TripleSkateBoard;

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
        else if (type == "SingleShell")
        {
            return SkateBoard;
        }
        else if (type == "DoubleShell")
        {
            return DoubleSkateBoard;
        }
        else if (type == "TripleShell")
        {
            return TripleSkateBoard;
        }
        return yerb;
    }
}
