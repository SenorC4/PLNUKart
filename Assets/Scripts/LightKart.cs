using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightKart : KartParent
{
    private Movement movement;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        setAcceleration(.003f);
        setHandling(8f);
        setTopSpeed(2f);
        movement.setStats(getAcceleration(), getTopSpeed(), getHandling());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
