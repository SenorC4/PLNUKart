using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurferBehavior : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float speed = 1f;
    [SerializeField] private int timeCap = 1000;

    private int timer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + (speed * Time.deltaTime), gameObject.transform.position.y, gameObject.transform.position.z);
        timer++;
        if (timer >= timeCap)
        {
            timer = 0;
            speed = -speed;
        }
    }
}
