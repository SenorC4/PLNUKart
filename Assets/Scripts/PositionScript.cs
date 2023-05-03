using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PositionScript : MonoBehaviour
{
    private string positionNum;
    private TextMeshProUGUI t;
    // Start is called before the first frame update
    void Start()
    {
        t = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = positionNum;
    }

    public void setPositionNum(string p)
    {
        positionNum = p;
    }
}
