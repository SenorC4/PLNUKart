using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KartPicker : MonoBehaviour
{

    public GameObject kart1;
    public GameObject kart2;
    public GameObject kart3;

    public Button kart1Button;
    public Button kart2Button;
    public Button kart3Button;

    public Vector3 rotation;

    private static string selected;
    private static string selected2;

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
                if (Physics.Raycast(ray, out hit) && (hit.transform.name).Contains("2")) {
                    Debug.Log( hit.transform.name);
                    selected2 = hit.transform.name;
                }else if(Physics.Raycast(ray, out hit)){
                    Debug.Log( hit.transform.name + "single");
                    selected = hit.transform.name;
                }
        }
    }

    



    public static string getSelectedKart(){
        return selected;
    }

    public static string getSelectedKart2(){
        return selected2;
    }
}
