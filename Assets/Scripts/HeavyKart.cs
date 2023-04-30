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
        setAcceleration(.001f);
        setHandling(6.5f);
        setTopSpeed(3f);
        GetComponent<Movement>().setStats(getAcceleration(), getTopSpeed(), getHandling(), false);
        setMovement(GetComponent<Movement>());
    }

    // Update is called once per frame
    void Update()
    {
        base.Update(pi);
    }
}
