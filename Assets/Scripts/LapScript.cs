using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LapScript : MonoBehaviour
{
    private int lapNum;
    private TextMeshProUGUI t;
    // Start is called before the first frame update
    void Start()
    {
        t = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = "Lap " + lapNum + "/2";
    }

    public void setLapNum(int l)
    {
        lapNum = l;
    }
}
