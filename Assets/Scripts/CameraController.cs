using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CameraController : MonoBehaviour
{
    Vector3 originalPos;
    float magnitude;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.localPosition;

        //if(){

        //}
    }

    // Update is called once per frame
    void Update()
    {
        magnitude = 0.0006f;

        if (Input.GetKey(KeyCode.W))
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            float z = originalPos.z; 

            transform.localPosition = new Vector3(x, y - 0.4064f, originalPos.z);
        }else{
            transform.localPosition = originalPos;
        }
    }
}
