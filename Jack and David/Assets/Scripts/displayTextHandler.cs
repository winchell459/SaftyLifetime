using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayTextHandler : MonoBehaviour
{
    public GameObject[] TriggerEventObjects;
    public GameObject text;
    public bool ActivateText;
    private bool triggered = false;


    // Update is called once per frame
    void Update()
    {
        if(triggered){
            text.gameObject.SetActive(ActivateText);
            foreach(GameObject triggerEvent in TriggerEventObjects){
                triggerEvent.SendMessage("TriggerEvent"); 
            }

            //if(TriggerEventObject)TriggerEventObject.SendMessage("TriggerEvent");
            triggered = false;
        }
    }

    public void TriggerEvent(){
        triggered = true;
    }
}
