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
        setAcceleration(.05f);
        setHandling(7f);
        setTopSpeed(4f);
        movement.setStats(getAcceleration(), getTopSpeed(), getHandling());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
