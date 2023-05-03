using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckScript : MonoBehaviour
{
    private int checkNum;
    private TextMeshProUGUI t;
    // Start is called before the first frame update
    void Start()
    {
        t = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = "Checkpoint " + checkNum + "/8";
    }

    public void setCheckNum(int c)
    {
        checkNum = c;
    }
}
