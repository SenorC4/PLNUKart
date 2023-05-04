using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckpointBehavior : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int checkNum;
    [SerializeField] private GameObject endScreen;

    [SerializeField] private TMP_Text end1;
    [SerializeField] private TMP_Text end2;

    private CheckParent cp;
    private MeshRenderer mr;

    private void Start()
    {
        cp = gameObject.GetComponentInParent<CheckParent>();
        mr = gameObject.GetComponent<MeshRenderer>();
        //endScreen.GetComponent<Renderer>().enabled = false;
        endScreen.GetComponent<Canvas>().enabled = false;

        
        //mr.forceRenderingOff = true;
    }

    public int getCheckNum()
    {
        return checkNum;
    }

    public void checkHit(int p)
    {
        if (cp.getCurrentCheck(p) == checkNum)
        {
            

            //mr.enabled = false;
            cp.setCurrentCheck(checkNum + 1, p);

            

            if (cp.getCurrentCheck(p) >= cp.getMax())
            {
                cp.setCurrentCheck(0, p);
                cp.setLaps(p);

                if(cp.getLaps(p) > 1){
                    if(MainMenu.getGameType() == "SplitScreen"){
                        if(p == 1){
                            
                            end2.text = "2nd";
                            end2.color = Color.gray;
                        }else{
                            end1.text = "2nd";
                            end1.color = Color.gray;
                        }
                    }else if(MainMenu.getGameType() == "TimeTrial"){
                        end1.gameObject.SetActive(false);
                        end2.gameObject.SetActive(false);

                    }
                endScreen.GetComponent<Canvas>().enabled = true;                    Time.timeScale = 0;
                }
            }
            Debug.Log("Player" + p + ": Checkpoint " + cp.getCurrentCheck(p));

           
        }
    }
}
