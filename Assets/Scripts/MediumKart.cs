using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumKart : KartParent
{
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        setAcceleration(.002f);
        setHandling(7f);
        setTopSpeed(2.5f);
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
