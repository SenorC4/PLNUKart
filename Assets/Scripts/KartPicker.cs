using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartPicker : MonoBehaviour
{

    public GameObject kart1;
    public GameObject kart2;
    public GameObject kart3;

    public Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        kart1.transform.Rotate(rotation * Time.deltaTime);
        kart2.transform.Rotate(rotation * Time.deltaTime);
        kart3.transform.Rotate(rotation * Time.deltaTime);

        if (Input.GetMouseButtonDown(0)) {
                RaycastHit  hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit)) {
                    Debug.Log( hit.transform.name);
                    if(hit.transform.name == "LightKart"){
                        

                    }



                }
        }

    }
}
