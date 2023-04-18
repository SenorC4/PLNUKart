using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyKart : KartParent
{
    private Movement movement;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        setAcceleration(.001f);
        setHandling(6.5f);
        setTopSpeed(3f);
        movement.setStats(getAcceleration(), getTopSpeed(), getHandling());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
