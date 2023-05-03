using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

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
    private bool started = false;

    public int countDownInt = 3;
    public TMP_Text countText;
    public GameObject startCanvas;

    private CheckScript cs;
    private LapScript ls;
    private PositionScript ps;

    private int laps = 0;
    private int currentCheck = 0;
    private string position = "1st";

    // Start is called before the first frame update
    void Start()
    {
        cs = gameObject.GetComponentInChildren<CheckScript>();
        ls = gameObject.GetComponentInChildren<LapScript>();
        ps = gameObject.GetComponentInChildren<PositionScript>();

        Application.targetFrameRate = 100;
        startCanvas = GameObject.Find("StartCanvas");
        countText = startCanvas.GetComponentInChildren<TMP_Text>();

        rb = gameObject.GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();


        StartCoroutine(countDown());
        


    }

    IEnumerator countDown(){
        
        while(countDownInt > 0){
            countText.text = countDownInt.ToString();

            yield return new WaitForSeconds(1f);

            countDownInt--;

        }

        countText.text = "GO";
        started = true;

        yield return new WaitForSeconds(1f);
        startCanvas.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        cs.setCheckNum(currentCheck);
        ls.setLapNum(laps+1);
        ps.setPositionNum(position);
        if(started){
            if (playerInput.actions["Move"].ReadValue<Vector2>().x >0.2f || playerInput.actions["Move"].ReadValue<Vector2>().x <-0.2f)
            {
                float change = handling * Mathf.Sign(playerInput.actions["Move"].ReadValue<Vector2>().x);
                Vector3 euler = new Vector3(0f, change, 0f);
                Quaternion rotation = Quaternion.Euler(euler * Time.fixedDeltaTime);
                rb.MoveRotation(rb.rotation * rotation);
            }
            if (playerInput.actions["Move"].ReadValue<Vector2>().y != 0)
            {
                currentSpeed += 30 * acceleration * Mathf.Sign(playerInput.actions["Move"].ReadValue<Vector2>().y);
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

    public void setLaps(int l)
    {
        laps = l;
    }

    public void setCurrentCheck(int c)
    {
        currentCheck = c;
    }
}
