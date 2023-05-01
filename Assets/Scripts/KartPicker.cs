using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class KartPicker : MonoBehaviour
{

    private List<GameObject> karts;

    public Vector3 rotation;

    private static string selected;
    private static string selected2;

    // Start is called before the first frame update
    void Start()
    {
        karts = new List<GameObject>();

        foreach(GameObject kart in GameObject.FindGameObjectsWithTag("Player")){
            karts.Add(kart);
        }
    }

    // Update is called once per frame
    void Update()
    {

        foreach(GameObject Kart in karts){
            Kart.transform.Rotate(rotation * Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(0)) {
            RaycastHit  hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && (hit.transform.name).Contains("2")) {
                //Debug.Log( hit.transform.name);
                selected2 = hit.transform.name;
            }else if(Physics.Raycast(ray, out hit)){
                //Debug.Log( hit.transform.name + "single");
                selected = hit.transform.name;
            }
        }
    }

    
    public void small(){
        selected = "LightKart";
    }

    public void medium(){
        selected = "MediumKart";
    }

    public void large(){
        selected = "HeavyKart";
    }

   public void small2(){
        selected2 = "LightKart2";
    }

    public void medium2(){
        selected2 = "MediumKart2";
    }

    public void large2(){
        selected2 = "HeavyKart2";
    }

    



    public static string getSelectedKart(){
        return selected;
    }

    public static string getSelectedKart2(){
        return selected2;
    }
}
