using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PositionScript : MonoBehaviour
{
    private string positionNum;
    private TextMeshProUGUI t;
    // Start is called before the first frame update
    void Start()
    {
        t = gameObject.GetComponent<TextMeshProUGUI>();
        if(MainMenu.getGameType() == "TimeTrial"){
            t.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(MainMenu.getGameType() == "SplitScreen"){

        
            t.text = positionNum;

            if(gameObject.transform.parent.transform.parent.transform.parent.tag == "player1"){
                if(CheckParent.getFirst() == 1){
                    setPositionNum("1st");
                }else{
                    setPositionNum("2nd");
                }
            }else if(gameObject.transform.parent.transform.parent.transform.parent.tag == "player2"){
                if(CheckParent.getFirst() == 2){
                    setPositionNum("1st");
                }else{
                    setPositionNum("2nd");
                }
            }else{
                Debug.Log("no");
            }
        }

    }

    public void setPositionNum(string p)
    {

        if(MainMenu.getGameType() == "SplitScreen"){
            positionNum = p;
            t.text = p;
        }
    }
}
