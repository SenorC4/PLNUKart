using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MediumKart : KartParent
{
    PlayerInput pi;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        pi = gameObject.GetComponent<PlayerInput>();
        setAcceleration(.002f);
        setHandling(10f);
        setTopSpeed(5f);
        GetComponent<Movement>().setStats(getAcceleration(), getTopSpeed(), getHandling(), false);
        setMovement(GetComponent<Movement>());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("test");
        base.Update(pi);
    }
}
