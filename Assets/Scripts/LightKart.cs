using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightKart : KartParent
{
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        setAcceleration(.003f);
        setHandling(8f);
        setTopSpeed(2f);
        GetComponent<Movement>().setStats(getAcceleration(), getTopSpeed(), getHandling(), false);
        setMovement(GetComponent<Movement>());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("test");
        base.Update();
    }
}
