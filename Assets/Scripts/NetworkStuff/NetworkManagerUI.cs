using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.Netcode.Transports.UTP;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField username;
    [SerializeField] private TMP_InputField ip;

    [SerializeField] private GameObject networkObject;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }


    public void host(){
        SceneManager.LoadScene("PLNUSouth");

        NetworkManager.Singleton.StartHost();
        

    }

    public void client(){
        networkObject.GetComponent<UnityTransport>().ConnectionData.Address= ip.text;
        NetworkManager.Singleton.StartClient();
        
    }



}
