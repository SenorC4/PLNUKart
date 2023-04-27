using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("Attributes")]
    private float acceleration = 0.01f;
    private float topSpeed = 4f;
    private float handling = 20f;
    //[SerializeField] private float acceleration = 0.01f;
    //[SerializeField] private float topSpeed = 4f;
    //[SerializeField] private float handling = 20f;
    [SerializeField] PlayerInput playerInput;

    private Rigidbody rb;
    private float currentSpeed = 0f;
    private int playerNum = 1;
    private bool isBoosting = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.actions["Move"].ReadValue<Vector2>().x != 0)
        {
            float change = handling * Mathf.Sign(playerInput.actions["Move"].ReadValue<Vector2>().x);
            Vector3 euler = new Vector3(0f, change, 0f);
            Quaternion rotation = Quaternion.Euler(euler * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * rotation);
        }
        if (playerInput.actions["Move"].ReadValue<Vector2>().y != 0)
        {
            
            currentSpeed += acceleration * Mathf.Sign(playerInput.actions["Move"].ReadValue<Vector2>().y);
            if (currentSpeed > topSpeed) currentSpeed = topSpeed;
            if (currentSpeed < -topSpeed / 2) currentSpeed = -topSpeed / 2;

            if(isBoosting){
                gameObject.GetComponent<AudioSource>().pitch = 0.99f;
            }else{
                gameObject.GetComponent<AudioSource>().pitch = 0.95f;
            }

        }
        else
        {
            if (currentSpeed > 0) currentSpeed -= acceleration;
            if (currentSpeed < 0) currentSpeed += acceleration;

            gameObject.GetComponent<AudioSource>().pitch = 0.9f;
            gameObject.GetComponent<AudioSource>().volume = 0.1f;
        }
        rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        rb.AddForce(rb.transform.forward * currentSpeed, ForceMode.Impulse);
    }

    public void setStats(float acceleration, float topSpeed, float handling, bool isBoosting)
    {
        this.acceleration = acceleration;
        //Debug.Log(this.acceleration);
        //Debug.Log(acceleration);
        this.topSpeed = topSpeed;
        this.handling = handling;
        this.isBoosting = isBoosting;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "grass")
        {
            if (isBoosting == false)
            {
                acceleration = 0.005f;
                topSpeed = 2f;
            }
        }
        if (collision.gameObject.tag == "road")
        {
            if (isBoosting == false)
            {
                acceleration = 0.01f;
                topSpeed = 4f;
            }
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
