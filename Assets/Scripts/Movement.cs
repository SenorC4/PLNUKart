using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Attributes")]
    private float acceleration = 0.01f;
    private float topSpeed = 4f;
    private float handling = 20f;
    //[SerializeField] private float acceleration = 0.01f;
    //[SerializeField] private float topSpeed = 4f;
    //[SerializeField] private float handling = 20f;

    private Rigidbody rb;
    private float currentSpeed = 0f;
    private int playerNum = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            float change = handling * Mathf.Sign(Input.GetAxisRaw("Horizontal"));
            Vector3 euler = new Vector3(0f, change, 0f);
            Quaternion rotation = Quaternion.Euler(euler * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * rotation);
        }
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            
            currentSpeed += acceleration * Mathf.Sign(Input.GetAxisRaw("Vertical"));
            if (currentSpeed > topSpeed) currentSpeed = topSpeed;
            if (currentSpeed < -topSpeed / 2) currentSpeed = -topSpeed / 2;
        }
        else
        {
            if (currentSpeed > 0) currentSpeed -= acceleration;
            if (currentSpeed < 0) currentSpeed += acceleration;
        }
        rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        rb.AddForce(rb.transform.forward * currentSpeed, ForceMode.Impulse);
    }

    public void setStats(float acceleration, float topSpeed, float handling)
    {
        this.acceleration = acceleration;
        this.topSpeed = topSpeed;
        this.handling = handling;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "grass")
        {
            acceleration = 0.005f;
            topSpeed = 2f;
        }
        if (collision.gameObject.tag == "road")
        {
            acceleration = 0.01f;
            topSpeed = 4f;
        }
    }

    public int getPlayerNum()
    {
        return playerNum;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "checkpoint")
        {
            other.gameObject.GetComponent<CheckpointBehavior>().checkHit(playerNum);
        }
    }
}
