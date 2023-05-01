using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeavyKart : KartParent
{
    PlayerInput pi;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        pi = gameObject.GetComponent<PlayerInput>();
        setAcceleration(.0005f);
        setHandling(12f);
        setTopSpeed(14f);
        GetComponent<Movement>().setStats(getAcceleration(), getTopSpeed(), getHandling(), false);
        setMovement(GetComponent<Movement>());
    }

    // Update is called once per frame
    void Update()
    {
        base.Update(pi);
    }
}
