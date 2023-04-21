using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public GameObject LightKart;
    public GameObject MediumKart;
    public GameObject HeavyKart;

    // Start is called before the first frame update
    void Start()
    {
        if("LightKart" == KartPicker.getSelectedKart()){
            Instantiate(LightKart, new Vector3(0, 2.44f, 0), Quaternion.identity);
        }else if("MediumKart" == KartPicker.getSelectedKart()){
            Instantiate(MediumKart, new Vector3(0, 2.7f, 0), Quaternion.identity);
        }else if("HeavyKart" == KartPicker.getSelectedKart()){
            Instantiate(HeavyKart, new Vector3(0, 3.1f, 0), Quaternion.identity);
        }else{
            Instantiate(MediumKart, new Vector3(0, 2.7f, 0), Quaternion.identity);
            Debug.Log("error, no kart selected");
        }

        Debug.Log("Created");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
