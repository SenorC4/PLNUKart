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
        bool testing = true;
        if(MainMenu.getGameType() == "SplitScreen"){
            GameObject player1 = (GameObject)Instantiate(MediumKart, new Vector3(-1, 2.7f, 0), Quaternion.identity);
            GameObject player2 = (GameObject)Instantiate(MediumKart, new Vector3(1, 2.7f, 0), Quaternion.identity);

            Transform cameraTransform = player1.transform.Find("Main Camera");
            Transform cameraTransform2 = player2.transform.Find("Main Camera");

            Camera camer1 = player1.GetComponentInChildren<Camera>();
            Camera camera2 = player2.GetComponentInChildren<Camera>();

            camera2.GetComponent<AudioListener>().enabled = false;

            camer1.rect = new Rect(0f,0f,0.5f,1f);
            camera2.rect = new Rect(0.5f,0f,0.5f,1f);


        }else{
            if("LightKart" == KartPicker.getSelectedKart()){
                Instantiate(LightKart, new Vector3(0, 2.44f, 0), Quaternion.identity);
            }else if("MediumKart" == KartPicker.getSelectedKart()){
                Instantiate(MediumKart, new Vector3(0, 2.7f, 0), Quaternion.identity);
            }else if("HeavyKart" == KartPicker.getSelectedKart()){
                Instantiate(HeavyKart, new Vector3(0, 3.1f, 0), Quaternion.identity);

            }else if(testing){
                Instantiate(MediumKart, new Vector3(0, 2.7f, 0), Quaternion.identity);
            Debug.Log("error, no kart selected");
        }
        }

        
        
        
        

        

        Debug.Log("Created");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
