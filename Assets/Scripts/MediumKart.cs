using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumKart : KartParent
{
    private Movement movement;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>(); 
        setAcceleration(.002f);
        setHandling(7f);
        setTopSpeed(2.5f);
        movement.setStats(getAcceleration(), getTopSpeed(), getHandling());
        setMovement(movement);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
