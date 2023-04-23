using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyKart : KartParent
{
    // Start is called before the first frame update
    void Start()
    {
        setAcceleration(.001f);
        setHandling(6.5f);
        setTopSpeed(3f);
        GetComponent<Movement>().setStats(getAcceleration(), getTopSpeed(), getHandling());
        setMovement(GetComponent<Movement>());
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
